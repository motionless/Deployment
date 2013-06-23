using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Motionless.Deployment.Admin.Extensions;
using Motionless.Deployment.Contracts.Data.Model;

namespace Motionless.Deployment.Admin.Models
{
	public class PackageViewModel : IPackage
	{
		public long Id { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public string Name { get; set; }
		public Version Version { get; set; }
		public string PackageUrl { get; set; }
		public ISet<IWebsite> Websites { get; set; }
		
		public ISet<ISetupStep> SetupSteps { get; set; }


		public IList<IProduct> Products { get; set; }
		public IProduct Product { get; set; }
		public long SelectedProductId { get; set; }
		public SelectList ProductsSelectList
		{
			get
			{
				var productItems = Products.Select(p => new SelectListItem() { Text = p.Name, Value = p.Id.ToString() }).ToList();

				productItems.Insert(0, new SelectListItem { Text = string.Format("<-{0}->", "No Product"), Value = "0" });
				return new SelectList(productItems,
										"Value",
										"Text",
										Product != null ? Product.Id : 0);
			}
		}

		public IList<IPackageConfiguration> PackageConfigurations { get; set; }
		public IPackageConfiguration PackageConfiguration { get; set; }
		public long SelectedPackageConfigurationId { get; set; }
		public SelectList PackageConfigurationsSelectList
		{
			get
			{
				var listItems = PackageConfigurations.Select(p => new SelectListItem() { Text = p.DisplayName(), Value = p.Id.ToString() }).ToList();

				listItems.Insert(0, new SelectListItem { Text = string.Format("<-{0}->", "No Package Configuration"), Value = "0" });
				return new SelectList(listItems,
										"Value",
										"Text",
										PackageConfiguration != null ? PackageConfiguration.Id : 0);
			}
		}
	}
}