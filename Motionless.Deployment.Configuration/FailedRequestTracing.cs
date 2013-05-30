namespace Motionless.Deployment.Configuration
{
	public class FailedRequestTracing
	{
		public string Directory { get; set; }
		public bool Enabled { get; set; }
		public uint MaximumNumberOfTraceFiles { get; set; }
	}
}