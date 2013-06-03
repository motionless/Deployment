using Motionless.Data.Persistence;

namespace Motionless.Deployment.Contracts.Data.Model
{
	public interface IServerRole : IBaseObject
	{
		string Name { get; set; }
		IServer Server { get; set; }
	}
}