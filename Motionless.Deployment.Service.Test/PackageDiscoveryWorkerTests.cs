using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootstrap;
using Bootstrap.AutoMapper;
using Bootstrap.Extensions.StartupTasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Motionless.Data.Persistence;

namespace Motionless.Deployment.Service.Test
{
	[TestClass]
	public class PackageDiscoveryWorkerTests
	{
		[ClassInitialize]
		public static void ClassInit(TestContext context)
		{
			PersistenceHelper.UpdateDatabaseSchema();
			Bootstrapper.With.AutoMapper().And.StartupTasks().Start();
		}

		[TestMethod]
		public void DiscoverNewPackages()
		{
			var discovery = new PackageDiscoveryWorker();
			discovery.ProcessPackageConfigurations();
		}
	}
}
