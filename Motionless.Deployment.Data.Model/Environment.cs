using System.Collections.Generic;
using Motionless.Data.Persistence;
using Motionless.Deployment.Contracts.Data.Model;
using Motionless.Deployment.Contracts.Enums;

namespace Motionless.Deployment.Data.Model
{
	public class Environment : BaseObject<Environment>, IEnvironment
	{

		public virtual string Name { get; set; }

		public virtual Stage Stage { get; set; }

		public virtual IProduct Product { get; set; }

		public virtual ISet<IServer> Servers { get; set; }

		

	}
}
