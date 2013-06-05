using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootstrap;
using Bootstrap.AutoMapper;
using Bootstrap.Extensions.StartupTasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Motionless.Data.Persistence;
using Motionless.Deployment.Contracts.Data.Model;
using Motionless.Deployment.Data.Model;

namespace Motionless.Deployment.Services.Test
{
	[TestClass]
	public class ProductServiceTests
	{
		static ProductService service;
		[ClassInitialize]
		public static void ClassInit(TestContext context)
		{
			PersistenceHelper.UpdateDatabaseSchema();
			Bootstrapper.With.AutoMapper().And.StartupTasks().Start();

			service = new ProductService();
		}

		[TestMethod]
		public void FindProduct()
		{
			var service = new ProductService();
			IProduct product = service.GetById(1);
		}

		[TestMethod]
		public void FindProducts()
		{
			using (var pc = PersistenceHelper.CreatePersistenceContext())
			{
				var service = new ProductService();
				var sortParams = new SortProperties<Product>() {{m => m.CreatedAt, SortOrder.Descending}};

				long totalCount;
				var results = service.GetAll(0, 2, true, sortParams, out totalCount);
			}
		}

		[TestMethod]
		public void CreateNewProduct()
		{
			using (var pc = PersistenceHelper.CreatePersistenceContext())
			{
				var product = new Product();
				product.Name = string.Format("New Product ({0})", DateTime.UtcNow.Ticks);

				pc.AfterCommitActions.Add(() => Console.WriteLine("Hello Wolrd! ({0})",product.Id));

				service.Create(product);
			}
		}
	}
}
