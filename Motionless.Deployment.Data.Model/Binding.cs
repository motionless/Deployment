using System.Collections.Generic;
using Motionless.Data.Persistence;
using Motionless.Deployment.Contracts.Data.Model;

namespace Motionless.Deployment.Data.Model
{
	public class Binding : BaseObject<Binding>, IBinding
	{
		public virtual IWebsite Website { get; set; }

		public virtual string Protocol { get; set; }

		public virtual string IPAddress { get; set; }

		public virtual int Port { get; set; }

		public virtual string Hostname { get; set; }

		public virtual string SslThumbPrint { get; set; }
		
		public virtual ISet<IEnvironment> Environments { get; set; }
		
		public virtual ISet<IServer> Servers { get; set; }
	}
}