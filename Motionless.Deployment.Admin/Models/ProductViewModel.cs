using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Motionless.Deployment.Contracts.Data.Model;

namespace Motionless.Deployment.Admin.Models
{
	public class ProductViewModel : IProduct
	{
		public long Id { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public string Name { get; set; }
		public Iesi.Collections.Generic.ISet<IEnvironment> Environments { get; set; }
		public Iesi.Collections.Generic.ISet<IPackage> Packages { get; set; }
	}
}