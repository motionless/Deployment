using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Motionless.Deployment.Contracts.Data.Model;
using Motionless.Deployment.Services;

namespace Motionless.Deployment.Service
{
	public class PackageDiscoveryWorker
	{
		private PackageConfigurationService PackageConfigurationService { get; set; }
		private PackageService PackageService { get; set; }
		private ProductService ProductService { get; set; }

		private Regex FilenamePattern = new Regex(@"^(.*?)_(\d+)\.(\d+)\.(\d+)\.zip$");

		/// <summary>
		/// Initializes a new instance of the <see cref="PackageDiscoveryWorker"/> class.
		/// </summary>
		public PackageDiscoveryWorker()
		{
			PackageConfigurationService = new PackageConfigurationService();
			ProductService = new ProductService();
			PackageService = new PackageService();
		}

		/// <summary>
		/// Processes all package configurations.
		/// </summary>
		public void ProcessPackageConfigurations()
		{
			// get all products that are configured
			IEnumerable<IProduct> products = ProductService.GetAll();
			// for each product try to find new packages
			foreach (IProduct product in products)
			{
				IPackageConfiguration configuration = null;

				if (product.PackageConfigurations != null)
				{
					configuration = product.PackageConfigurations
					                       .Where(config => config.IsActive)
					                       .OrderByDescending(config => config.UpdatedAt)
					                       .FirstOrDefault();
				}

				Version lastPackageVersion = null;
				if (product.Packages != null)
				{
					var packageWithHighestVersion = product.Packages.OrderBy(package => package.Version).LastOrDefault();
					if (packageWithHighestVersion != null)
					{
						lastPackageVersion = packageWithHighestVersion.Version;
					}
				}

				if (configuration != null)
				{
					if (configuration.SearchPath != null)
					{
						string lastFileName = null;

						if (lastPackageVersion != null)
						{
							lastFileName = string.Format("{0}_{1}.{2}.{3}.zip", 
							                             configuration.Name, 
							                             lastPackageVersion.Major,
							                             lastPackageVersion.Minor, 
							                             lastPackageVersion.Build);
						}
						
						if (Directory.Exists(configuration.SearchPath))
						{
							foreach (string packageUrl in Directory.EnumerateFiles(configuration.SearchPath, configuration.SearchPattern))
							{
								var fileName = new FileInfo(packageUrl).Name;

								if (String.Compare(fileName, lastFileName, StringComparison.InvariantCultureIgnoreCase) > 0)
								{
									//create package for this configuration
									IPackage package = PackageService.CreateInstance();
									Match matches = FilenamePattern.Match(fileName);

									if (matches.Success)
									{
										package.Name = matches.Groups[1].Value;

										int major;
										if (int.TryParse(matches.Groups[2].Value, out major))
										{
											int minor;
											if (int.TryParse(matches.Groups[3].Value, out minor))
											{
												int build;
												if (int.TryParse(matches.Groups[4].Value, out build))
												{
													package.Version = new Version(major, minor, build);
												}
											}
										}
									}

									package.Name = fileName;
									package.Product = product;
									package.Websites = configuration.Websites;
									package.SetupSteps = configuration.SetupSteps;
									package.PackageUrl = packageUrl;
								}
							}
						}

					}
				}
			}
		}
	}
}

