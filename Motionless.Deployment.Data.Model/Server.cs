using Motionless.Data.Persistence;

namespace Motionless.Deployment.Data.Model
{
	public class Server : BaseObject<Server>
	{
		public virtual string Name { get; set; }
		
		public virtual Iesi.Collections.Generic.ISet<ServerRole> ServerRoles { get; set; }

		public virtual Environment Environment { get; set; }


	}
}
