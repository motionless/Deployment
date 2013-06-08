using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Motionless.Deployment.Contracts.Data.Model;
using Motionless.Deployment.Contracts.Enums;

namespace Motionless.Deployment.Admin.Models
{
	public class EnvironmentViewModel : IEnvironment
	{
		public long Id { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public string Name { get; set; }
		public Stage Stage { get; set; }
		public SelectList StagesSelectList
		{
			get
			{
				var stageItems = Enum.GetNames(typeof (Stage))
				                     .Select(name => new SelectListItem()
					                                     {
						                                     Text = name,
						                                     Value = name
					                                     });
				return new SelectList(stageItems,
										"Value",
										"Text",
										Stage);
			}
		}
	
		public IList<IProduct> Products { get; set; }
		public IProduct Product { get; set; }
		public long SelectedProductId { get; set; }
		public SelectList ProductsSelectList
		{
			get
			{
				var productItems = Products.Select(p => new SelectListItem() {Text = p.Name, Value = p.Id.ToString()}).ToList();

				productItems.Insert(0, new SelectListItem { Text = string.Format("<-{0}->", "No Product"), Value = "0" });
				return new SelectList(productItems,
										"Value",
										"Text",
										Product != null ? Product.Id : 0);
			}
		}
		
		public ISet<IServer> Servers { get; set; }
	}
}