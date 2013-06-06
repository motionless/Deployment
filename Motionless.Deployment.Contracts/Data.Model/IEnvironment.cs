using System.Collections.Generic;
using Motionless.Data.Persistence;
using Motionless.Deployment.Contracts.Enums;

namespace Motionless.Deployment.Contracts.Data.Model
{
	public interface IEnvironment : IBaseObject
	{
		string Name { get; set; }
		Stage Stage { get; set; }
		IProduct Product { get; set; }
		ISet<IServer> Servers { get; set; }
	}
}