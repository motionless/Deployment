using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Motionless.Data.Persistence;
using Motionless.Deployment.Contracts.Data.Model;

namespace Motionless.Deployment.Services.Test
{
	[TestClass]
	public class ProductServiceTests
	{
		[ClassInitialize]
		public static void ClassInit(TestContext context)
		{
			PersistenceHelper.UpdateDatabaseSchema();
		}

		[TestMethod]
		public void FindProduct()
		{
			var service = new ProductService();
			IProduct product = service.FindById(1);
		}

		[TestMethod]
		public void FindProducts()
		{
			
		}
	}
}
