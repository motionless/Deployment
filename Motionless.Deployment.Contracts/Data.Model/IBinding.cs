using System.Collections.Generic;
using Motionless.Data.Persistence;

namespace Motionless.Deployment.Contracts.Data.Model
{
	public interface IBinding : IBaseObject
	{
		IWebsite Website { get; set; }
		string Protocol { get; set; }
		string IPAddress { get; set; }
		int Port { get; set; }
		string Hostname { get; set; }
		string SslThumbPrint { get; set; }
		ISet<IEnvironment> Environments { get; set; }
		ISet<IServer> Servers { get; set; }
	}
}