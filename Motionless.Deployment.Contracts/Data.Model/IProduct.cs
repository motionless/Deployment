using System.Collections.Generic;
using Motionless.Data.Persistence;

namespace Motionless.Deployment.Contracts.Data.Model
{
	public interface IProduct : IBaseObject
	{
		string Name { get; set; }
		ISet<IEnvironment> Environments { get; set; }
		ISet<IPackage> Packages { get; set; }
		ISet<IPackageConfiguration> PackageConfigurations { get; set; }
	}
}