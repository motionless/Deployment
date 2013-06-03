using Motionless.Data.Persistence;

namespace Motionless.Deployment.Contracts.Data.Model
{
	public interface IProduct : IBaseObject
	{
		string Name { get; set; }
		Iesi.Collections.Generic.ISet<IEnvironment> Environments { get; set; }
		Iesi.Collections.Generic.ISet<IPackage> Packages { get; set; }
	}
}