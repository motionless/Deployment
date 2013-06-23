using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Motionless.Deployment.Admin.Extensions;
using Motionless.Deployment.Contracts.Data.Model;
using Motionless.Deployment.Data.Model;

namespace Motionless.Deployment.Admin.Models
{
	public class WebsiteViewModel : IWebsite
	{
		public WebsiteViewModel()
		{
			ApplicationPool = new ApplicationPoolViewModel();
		}

		public long Id { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public IApplicationPool ApplicationPool { get; set; }
		public string Name { get; set; }
		public string PhysicalPath { get; set; }
		public ISet<IBinding> Bindings { get; set; }
		public ISet<IVirtualDirectory> VirtualDirectories { get; set; }

		public List<IPackageConfiguration> PackageConfigurations { get; set; }
		public IPackageConfiguration PackageConfiguration { get; set; }
		public long SelectedPackageConfigurationId { get; set; }
		public SelectList PackageConfigurationsSelectList
		{
			get
			{
				var listItems = PackageConfigurations.Select(p => new SelectListItem() { Text = p.DisplayName(), Value = p.Id.ToString() }).ToList();
				listItems.Insert(0, new SelectListItem { Text = string.Format("<-{0}->", "No Package Configuration"), Value = "0" });

				SelectedPackageConfigurationId = PackageConfiguration != null ? PackageConfiguration.Id : 0;
				return new SelectList(listItems,
										"Value",
										"Text",
										SelectedPackageConfigurationId);
			}
		}

	}
}