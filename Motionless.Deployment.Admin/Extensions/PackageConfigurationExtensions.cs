using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Motionless.Deployment.Contracts.Data.Model;

namespace Motionless.Deployment.Admin.Extensions
{
	public static class PackageConfigurationExtensions
	{
		public static string DisplayName(this IPackageConfiguration packageConfiguration)
		{
			var product = packageConfiguration.Product;
			string displayName;
			if (product != null)
			{
				displayName = string.Format("{0} Config {1}", product.Name, packageConfiguration.Version.ToString());
			}
			else
			{
				displayName = packageConfiguration.Name;
			}
			return displayName;
		}
	}
}