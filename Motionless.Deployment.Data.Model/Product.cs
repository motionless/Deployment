using Motionless.Data.Persistence;
using Motionless.Deployment.Contracts.Data.Model;

namespace Motionless.Deployment.Data.Model
{
	public class Product : BaseObject<Product>, IProduct
	{
		public virtual string Name { get; set; }
		public virtual Iesi.Collections.Generic.ISet<IEnvironment> Environments { get; set; }
		public virtual Iesi.Collections.Generic.ISet<IPackage> Packages { get; set; }
	}
}
