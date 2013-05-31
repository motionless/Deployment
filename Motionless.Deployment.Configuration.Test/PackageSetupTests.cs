using Microsoft.VisualStudio.TestTools.UnitTesting;
using Motionless.Deployment.Data.Model;

namespace Motionless.Deployment.Configuration.Test
{
	[TestClass]
	public class PackageSetupTests
	{
		[TestMethod]
		public void CreateWebsite()
		{
			var website = new Website
				              {
					              Name = "Test Website",
					              PhysicalPath = @"C:\windows\temp",
					              ApplicationPool = new ApplicationPool()
						                                {
							                                Enable32BitAppOnWin64 = false,
							                                IdleTimeout = 0,
							                                ManagedRuntimeVersion = "v4.0",
							                                MaxProcesses = 1,
							                                Name = "Test Application Pool",
							                                PeriodicRestartTime = 0,
							                                Identity = "NetworkService"
						                                }
				              };
			website.Bindings.Add(new Binding()
				                     {
										 Hostname = "www.keine-ahnung.de",
										 Port = 80,
										 Protocol = "http",
										 Website = website
				                     });
			website.Bindings.Add(new Binding()
				                     {
					                     Hostname = "www.keine-ahnung.de",
					                     Port = 443,
					                     Protocol = "https",
					                     Website = website,
										 SslThumbPrint = "8AFB1487462DEF7EB64FCEB5F57478E30FFD105D"
				                     });

			var package = new Package();
			package.Websites.Add(website);

			var setup = new PackageSetup();
			setup.InstallPackage(package);

		}
	}
}
