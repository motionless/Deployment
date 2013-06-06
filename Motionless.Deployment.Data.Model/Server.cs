using System.Collections.Generic;
using Motionless.Data.Persistence;
using Motionless.Deployment.Contracts.Data.Model;

namespace Motionless.Deployment.Data.Model
{
	public class Server : BaseObject<Server>, IServer
	{
		public virtual string Name { get; set; }
		
		public virtual ISet<IServerRole> ServerRoles { get; set; }

		public virtual ISet<IEnvironment> Environments { get; set; }

	}
}
