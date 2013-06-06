using System.Collections.Generic;

using Motionless.Data.Persistence;
using System;
using Motionless.Deployment.Contracts.Data.Model;

namespace Motionless.Deployment.Data.Model
{
	public class Package : BaseObject<Package>, IPackage
	{
		public Package()
		{
			Websites = new SortedSet<IWebsite>();
			SetupSteps = new SortedSet<ISetupStep>();
		}

		public virtual string Name { get; set; }

		public virtual Version Version { get; set; }

		public virtual string PackageUrl { get; set; }

		public virtual ISet<IWebsite> Websites { get; set; }

		public virtual IProduct Product { get; set; }

		public virtual ISet<ISetupStep> SetupSteps { get; set; }

	}
}
