using Motionless.Data.Persistence;

namespace Motionless.Deployment.Contracts.Data.Model
{
	public interface ISetupStep : IBaseObject
	{
		IPackage Package { get; set; }
		string Name { get; set; }
		int Order { get; set; }
	}
}