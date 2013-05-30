namespace Motionless.Deployment.Configuration
{
	public class ConnectionLimits
	{
		/// <summary>
		/// Connection Time-out (seconds)
		/// </summary>
		public int ConnectionTimeout { get; set; }

		/// <summary>
		/// Maximum Bandwidth (Bytes/second)
		/// </summary>
		public uint MaximumBandwidth { get; set; }

		/// <summary>
		/// Maximum Concurrent Connections
		/// </summary>
		public uint MaximumConcurrentConnections { get; set; }
	}
}