using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Motionless.Data.Persistence;
using Motionless.Deployment.Contracts.Data.Model;
using Motionless.Deployment.Contracts.Services;
using Motionless.Deployment.Data.Model;

namespace Motionless.Deployment.Services
{
	[Export(typeof(IEnvironmentService))]
	public class EnvironmentService : BaseService<Data.Model.Environment,IEnvironment>, IEnvironmentService
	{
		public IEnumerable<IEnvironment> GetAllByProduct(IProduct product)
		{
			if (product != null)
			{
				return Environment.Queryable.Where(env => env.Product != null && env.Product.Id == product.Id).ToList();
			}
			return null;
		}
	}
}
