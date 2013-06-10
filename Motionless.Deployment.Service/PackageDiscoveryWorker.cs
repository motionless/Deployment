using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Motionless.Deployment.Contracts.Data.Model;
using Motionless.Deployment.Services;

namespace Motionless.Deployment.Service
{
	public class PackageDiscoveryWorker
	{
		public PackageConfigurationService PackageConfigurationService { get; set; }
		public ProductService ProductService { get; set; }

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
			var products = ProductService.GetAll();
			foreach (IProduct product in products)
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
							var lastFileName = string.Format("{0}_{1}.{2}.{3}.zip", name, version.Major, version.MajorRevision, version.Minor);
							foreach (string file in Directory.EnumerateFiles(packageConfiguration.SearchPath, packageConfiguration.SearchPattern))
							{
								if (System.String.Compare(file, lastFileName, System.StringComparison.InvariantCultureIgnoreCase) > 0)
								{	
									//create package for this configuration
								}
							}

						}
					}
				}
			}
		}
	}
}
