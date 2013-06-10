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
		}

		/// <summary>
		/// Processes all package configurations.
		/// </summary>
		public void ProcessPackageConfigurations()
		{
			
			IEnumerable<IProduct> products = ProductService.GetAll();
			foreach (IProduct product in products)
			{
				if (product.PackageConfigurations != null)
				{
					var configurations = product.PackageConfigurations.Where(config => config.IsActive).ToList();
					foreach (IPackageConfiguration packageConfiguration in configurations)
					{
						var lastPackageForConfiguration = packageConfiguration.Packages.OrderBy(package => package.CreatedAt).LastOrDefault();
						if (lastPackageForConfiguration != null)
						{
							var version = lastPackageForConfiguration.Version;
							var name = lastPackageForConfiguration.Name;

							if (packageConfiguration.SearchPath != null)
							{
								var lastFileName = string.Format("{0}_{1}.{2}.{3}.zip", name, version.Major, version.Minor, version.Build);
								foreach (string file in Directory.EnumerateFiles(packageConfiguration.SearchPath, packageConfiguration.SearchPattern))
								{
									if (String.Compare(file, lastFileName, StringComparison.InvariantCultureIgnoreCase) > 0)
									{	
										//create package for this configuration
										IPackage package = PackageService.CreateInstance();
										Match matches = FilenamePattern.Match(file);

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
														package.Version = new Version(major,minor,build);
													}
												}
											}
										}
										package.Product = product;
										package.Websites = packageConfiguration.Websites;
										package.SetupSteps = packageConfiguration.SetupSteps;
										package.PackageUrl = file;
									}
								}

							}
						}
					}
				}
			}
		}
	}
}
