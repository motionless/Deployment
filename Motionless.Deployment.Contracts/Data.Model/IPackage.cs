using System;
using Motionless.Data.Persistence;

namespace Motionless.Deployment.Contracts.Data.Model
{
	public interface IPackage : IBaseObject
	{
		string Name { get; set; }
		Version Version { get; set; }
		string PackageUrl { get; set; }
		Iesi.Collections.Generic.ISet<IWebsite> Websites { get; set; }
		IProduct Product { get; set; }
		Iesi.Collections.Generic.ISet<ISetupStep> SetupSteps { get; set; }
	}
}