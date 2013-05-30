using Motionless.Data.Persistence;

namespace Motionless.Deployment.Data.Model
{
	public class ApplicationPool : BaseObject<ApplicationPool>
	{
		public virtual string Name { get; set; }

		public virtual string ManagedRuntimeVersion { get; set; }

		public virtual string PoolIdentity { get; set; }

		public virtual string IdentityPassword { get; set; }

		public virtual bool Enable32BitAppOnWin64 { get; set; }

		public virtual int IdleTimeout { get; set; }

		public virtual int PeriodicRestartTime { get; set; }

		public virtual int MaxProcesses { get; set; }
	}
}