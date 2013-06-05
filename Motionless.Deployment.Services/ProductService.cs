using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Motionless.Data.Persistence;
using Motionless.Deployment.Contracts.Data.Model;
using Motionless.Deployment.Contracts.Services;
using Motionless.Deployment.Data.Model;

namespace Motionless.Deployment.Services
{
	[Export(typeof(IProductService))]
	public class ProductService : BaseService<Product,IProduct>, IProductService
	{
		
	}
}
