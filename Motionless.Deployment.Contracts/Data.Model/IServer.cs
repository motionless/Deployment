using Motionless.Data.Persistence;

namespace Motionless.Deployment.Contracts.Data.Model
{
	public interface IServer : IBaseObject
	{
		string Name { get; set; }
		Iesi.Collections.Generic.ISet<IServerRole> ServerRoles { get; set; }
		Iesi.Collections.Generic.ISet<IEnvironment> Environments { get; set; }
	}
}