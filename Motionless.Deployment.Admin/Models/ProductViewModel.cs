using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Motionless.Deployment.Contracts.Data.Model;

namespace Motionless.Deployment.Admin.Models
{
	public class ProductViewModel : IProduct
	{
		public ProductViewModel()
		{
			Id = 0;
		}
		
		public long Id { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public string Name { get; set; }
		public ISet<IEnvironment> Environments { get; set; }
		public ISet<IPackage> Packages { get; set; }

		public ISet<IPackageConfiguration> PackageConfigurations { get; set; }
	}
}