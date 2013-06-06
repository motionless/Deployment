using System.Collections.Generic;
using Motionless.Data.Persistence;
using Motionless.Deployment.Contracts.Data.Model;

namespace Motionless.Deployment.Data.Model
{
	public class Product : BaseObject<Product>, IProduct
	{

		public Product()
		{
			//Environments = new OrderedSet<IEnvironment>();
			//Packages = new OrderedSet<IPackage>();
		}
		public virtual string Name { get; set; }
		public virtual ISet<IEnvironment> Environments { get; set; }
		public virtual ISet<IPackage> Packages { get; set; }
	}
}
