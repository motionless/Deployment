using System;

public class ApplicationPool
{
	
	public string FrameworkVersion { get; set; }
	public bool Enable32BitApplications { get; set; }
	public string ManagedPipelineMode { get; set; }
	public string Name { get; set; }
	
	public int QueueLength { get; set; }
	public bool StartAutomatically { get; set; }

	public int CpuLimit { get; set; }
	public string CpuLimitAction { get; set; }

	/// <summary>
	/// CPU Limit Interval (minutes)
	/// </summary>
	public int CpuLimitInterval { get; set; }


	public string Identity { get; set; }
	public int IdleTimeout { get; set; }
	public bool LoadUserProfile { get; set; }
	public int MaximumWorkerProcesses { get; set; }
	public bool PingEnabled { get; set; }
	/// <summary>
	/// (seconds)
	/// </summary>
	public int PingMamixmumResponseTime { get; set; }
	public int PingPeriod { get; set; }
	public int ShutdownTimeLimit { get; set; }
	public int StartupTimeLimit { get; set; }

	public bool ProcessOrphaningEnabled { get; set; }
	public string ProcessOrphaningExecutable { get; set; }
	public string ProcessOrphaningExecutableParameters { get; set; }

	public int RecyclingRegularTimeInterval { get; set; }
	public int RecyclingRequestLimit { get; set; }

	public bool RapidFailProtectionEnabled { get; set; }
	public int RapidFailProtectionMaximumFailures { get; set; }
	public int RapidFailProtectionFailureInterval { get; set; }

}
