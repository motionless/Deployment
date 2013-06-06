using System;
using System.Collections.Generic;
using Motionless.Data.Persistence;

namespace Motionless.Deployment.Contracts.Data.Model
{
	public interface IPackage : IBaseObject
	{
		string Name { get; set; }
		Version Version { get; set; }
		string PackageUrl { get; set; }
		ISet<IWebsite> Websites { get; set; }
		IProduct Product { get; set; }
		ISet<ISetupStep> SetupSteps { get; set; }
	}
}