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
using Motionless.Deployment.Data.Model;

namespace Motionless.Deployment.Service.Test
{
	[TestClass]
	public class DeploymentWorkerTests
	{
		[ClassInitialize]
		public static void ClassInit(TestContext context)
		{
			PersistenceHelper.UpdateDatabaseSchema();
			Bootstrapper.With.AutoMapper().And.StartupTasks().Start();
		}

		public void InstallWebserverPackage()
		{
			var packageConfiguration = new PackageConfiguration();

			var website = new Website();

			var product = new Product();

			var setupStep = new SetupStep();
			

			var package = new Package
				              {
								  Id = 92,
								  Name = "TestPackage_1.0.17.zip",
								  IsDeleted = false,
								  CreatedAt = DateTime.UtcNow.AddDays(-20),
					              UpdatedAt = DateTime.UtcNow.AddDays(-18),
					              PackageUrl = @"\\path\to\test\package\TestPackage_1.0.17.zip",
					              Version = new Version(1, 0, 17),
					              PackageConfiguration = null,
					              Websites = null,
								  Product = null,
								  SetupSteps = null
				              };
		}
	}
}
