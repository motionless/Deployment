using System.Collections.Generic;

namespace Motionless.Deployment.Configuration
{
	public class Website
	{
		public string Name { get; set; }
		public int Id { get; set; }
		public string ApplicationPool { get; set; }
		public string PhysicalPath { get; set; }
		public string PhysicalPathCredentials { get; set; }
		public string PhysicalPathCredentialsLogonType { get; set; }
		public string StartAutomatically { get; set; }
		public List<string> EnabledProtocols { get; set; }

		public List<Binding> Bindings { get; set; }
		
		
	}
}
