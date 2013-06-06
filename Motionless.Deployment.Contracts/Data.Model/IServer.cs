using System.Collections.Generic;
using Motionless.Data.Persistence;

namespace Motionless.Deployment.Contracts.Data.Model
{
	public interface IServer : IBaseObject
	{
		string Name { get; set; }
		ISet<IServerRole> ServerRoles { get; set; }
		ISet<IEnvironment> Environments { get; set; }
	}
}