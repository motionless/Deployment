﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Motionless.Deployment.Contracts.Data.Model;
using System.Web.Mvc;

namespace Motionless.Deployment.Admin.Models
{
	public class PackageConfigurationViewModel : IPackageConfiguration
	{
		public long Id { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public string Name { get; set; }
		public Version Version { get; set; }
		public bool IsActive { get; set; }
		public ISet<IPackage> Packages { get; set; }
		
		public string SearchPath { get; set; }
		public string SearchPattern { get; set; }
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
	}
}