using System.ComponentModel.Composition;
using Motionless.Data.Persistence;
using Motionless.Deployment.Contracts.Data.Model;

namespace Motionless.Deployment.Services
{
	[Export(typeof(IEnvironmentService))]
	public class EnvironmentService : BaseService<Data.Model.Environment,IEnvironment>, IEnvironmentService
	{
		
	}
}
