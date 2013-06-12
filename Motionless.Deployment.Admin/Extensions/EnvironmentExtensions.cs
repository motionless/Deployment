using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Motionless.Deployment.Contracts.Data.Model;

namespace Motionless.Deployment.Admin.Extensions
{
	public static class EnvironmentExtensions
	{
		public static string DisplayName(this IEnvironment environment)
		{
			var product = environment.Product;
			string displayName;
			if (product != null)
			{
				displayName = string.Format("{0} - {1}", product.Name, environment.Name);
			}
			else
			{
				displayName = environment.Name;
			}
			return displayName;
		}
	}
}