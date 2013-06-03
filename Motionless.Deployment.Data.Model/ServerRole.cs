using Motionless.Data.Persistence;
using Motionless.Deployment.Contracts.Data.Model;

namespace Motionless.Deployment.Data.Model
{
	public class ServerRole : BaseObject<ServerRole>, IServerRole
	{
		public virtual string Name {get;set;}
		public virtual IServer Server {get;set;}
	}
}
