using Motionless.Data.Persistence;

namespace Motionless.Deployment.Data.Model
{
	public class Product : BaseObject<Product>
	{
		public virtual string Name { get; set; }
		public virtual Iesi.Collections.Generic.ISet<Environment> Environments { get; set; }
		public virtual Iesi.Collections.Generic.ISet<Package> Packages { get; set; }
	}
}
