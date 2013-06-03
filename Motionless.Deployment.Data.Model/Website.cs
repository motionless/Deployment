using Iesi.Collections.Generic;
using Motionless.Data.Persistence;
using Motionless.Deployment.Contracts.Data.Model;

namespace Motionless.Deployment.Data.Model
{
	public class Website : BaseObject<Website>, IWebsite
	{
		public Website()
		{
			Bindings = new HashedSet<IBinding>();
			VirtualDirectories = new HashedSet<IVirtualDirectory>();
		}

		public virtual IApplicationPool ApplicationPool { get; set; }

		public virtual string Name { get; set; }

		public virtual string PhysicalPath { get; set; }

		public virtual Iesi.Collections.Generic.ISet<IBinding> Bindings { get; set; }

		public virtual Iesi.Collections.Generic.ISet<IVirtualDirectory> VirtualDirectories { get; set; }

	}
}
