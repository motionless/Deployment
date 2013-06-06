using System.ComponentModel.Composition;
using Motionless.Data.Persistence;
using Motionless.Deployment.Contracts.Data.Model;
using Motionless.Deployment.Contracts.Services;

namespace Motionless.Deployment.Services
{
	[Export(typeof(ISetupStepService))]
	public class SetupStepService : BaseService<Data.Model.SetupStep, ISetupStep>, ISetupStepService
	{
		
	}
}