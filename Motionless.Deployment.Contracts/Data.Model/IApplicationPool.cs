using Motionless.Data.Persistence;

namespace Motionless.Deployment.Contracts.Data.Model
{
	public interface IApplicationPool : IBaseObject
	{
		string Name { get; set; }
		string ManagedRuntimeVersion { get; set; }
		string Identity { get; set; }
		string IdentityPassword { get; set; }
		bool Enable32BitAppOnWin64 { get; set; }
		int IdleTimeout { get; set; }
		int PeriodicRestartTime { get; set; }
		int MaxProcesses { get; set; }
	}
}