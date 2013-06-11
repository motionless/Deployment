using System.Collections.Generic;
using Motionless.Data.Persistence;
using Motionless.Deployment.Contracts.Data.Model;

namespace Motionless.Deployment.Contracts.Services
{
	public interface IEnvironmentService : IBaseService<IEnvironment>
	{
		IEnumerable<IEnvironment> GetAllByProduct(IProduct product);
	}
}