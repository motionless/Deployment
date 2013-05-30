using Motionless.Data.Persistence;

namespace Motionless.Deployment.Data.Model
{
	public class Website : BaseObject<Website>
	{
		public virtual ApplicationPool ApplicationPool { get; set; }

		public virtual string Name { get; set; }

		public virtual Iesi.Collections.Generic.ISet<Binding> Bindings { get; set; }

		public virtual Iesi.Collections.Generic.ISet<VirtualDirectory> VirtualDirectories { get; set; }

	}
}
