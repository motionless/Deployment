using Motionless.Data.Persistence;

namespace Motionless.Deployment.Data.Model
{
	public class Binding : BaseObject<Binding>
	{
		public virtual Website Website { get; set; }

		public virtual string Protocol { get; set; }

		public virtual string IPAddress { get; set; }

		public virtual int Port { get; set; }

		public virtual string Hostname { get; set; }

		public virtual string SslThumbPrint { get; set; }
	}
}