using Motionless.Data.Persistence;

namespace Motionless.Deployment.Data.Model
{
	public class Binding : BaseObject<Binding>
	{
		public virtual int Protocol
		{
			get;
			set;
		}

		public virtual string IPAddress
		{
			get;
			set;
		}

		public virtual int Port
		{
			get;
			set;
		}

		public virtual int Hostname
		{
			get;
			set;
		}

		public virtual int SslThumbPrint
		{
			get;
			set;
		}
	}
}
