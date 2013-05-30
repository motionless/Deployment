using Motionless.Data.Persistence;
using System;

namespace Motionless.Deployment.Data.Model
{
	public class Package : BaseObject<Package>
	{
		public virtual string Name { get; set; }

		public virtual Version Version { get; set; }

		public virtual string PackageUrl { get; set; }

		public virtual Iesi.Collections.Generic.ISet<Website> Websites { get; set; }

		public virtual Product Product { get; set; }

		public virtual Iesi.Collections.Generic.ISet<SetupStep> SetupSteps { get; set; }

	}
}
