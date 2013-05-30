using Motionless.Data.Persistence;

namespace Motionless.Deployment.Data.Model
{
	public class Environment : BaseObject<Environment>
	{
		public virtual string Name { get; set; }

		public virtual Stage Stage { get; set; }

		public virtual Product Product { get; set; }

		public virtual Iesi.Collections.Generic.ISet<Server> Servers { get; set; }

	}
}
