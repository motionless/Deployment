using Motionless.Data.Persistence;
using Motionless.Deployment.Contracts.Enums;

namespace Motionless.Deployment.Contracts.Data.Model
{
	public interface IEnvironment : IBaseObject
	{
		string Name { get; set; }
		Stage Stage { get; set; }
		IProduct Product { get; set; }
		Iesi.Collections.Generic.ISet<IServer> Servers { get; set; }
	}
}