using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Motionless.Data.Persistence;
using Motionless.Deployment.Contracts.Data.Model;

namespace Motionless.Deployment.Data.Model.Test
{
	[TestClass]
	public class ParameterModelTest
	{
		[ClassInitialize]
		public static void ClassInit(TestContext context)
		{
			PersistenceHelper.Initialize();
			PersistenceHelper.UpdateDatabaseSchema();
		}




		[TestMethod]
		public void AddParamterTest()
		{
			using ( var pc = PersistenceHelper.CreatePersistenceContext())
			{
				var parameter = new Parameter { Name = "TestParameter", Value = "dev" };

				parameter.SaveOrUpdate();
			}
		}

		[TestMethod]
		public void AddParamterToEnvironmentTest()
		{
			using (var pc = PersistenceHelper.CreatePersistenceContext())
			{
				var parameter = new Parameter {Name = "TopLevelDomain", Value = "dev"};

				var firstEnvironment = Environment.Queryable.FirstOrDefault();
				
				if (firstEnvironment != null)
				{
					if (firstEnvironment.Parameters != null)
					{
						if (firstEnvironment.Parameters.Any(param => param.Name == "TopLevelDomain"))
						{
							var parameters = firstEnvironment.Parameters.Where(param => param.Name == "TopLevelDomain");
							foreach (IParameter param in parameters)
							{
								param.IsDeleted = true;
							}
						}
					}

					
				}
				else
				{
					firstEnvironment = new Environment()
						                   {
							                   Name = "First Test Environment",
						                   };

				}

				firstEnvironment.SaveOrUpdate();
				parameter.Owner = firstEnvironment;
				parameter.SaveOrUpdate();
				pc.VoteCommit();
			}
		}


		[TestMethod]
		public void AddParamterToProductTest()
		{
			using (var pc = PersistenceHelper.CreatePersistenceContext())
			{
				var parameter = new Parameter { Name = "TopLevelDomain", Value = "dev" };

				var firstProduct = Product.Queryable.FirstOrDefault();

				if (firstProduct != null)
				{
					if (firstProduct.Parameters != null)
					{
						if (firstProduct.Parameters.Any(param => param.Name == "TopLevelDomain"))
						{
							var parameters = firstProduct.Parameters.Where(param => param.Name == "TopLevelDomain");
							foreach (IParameter param in parameters)
							{
								param.IsDeleted = true;
							}
						}
					}


				}
				else
				{
					firstProduct = new Product()
					{
						Name = "First Test Environment",
					};

				}

				firstProduct.SaveOrUpdate();
				parameter.Owner = firstProduct;
				parameter.SaveOrUpdate();
				pc.VoteCommit();
			}
		}

	}
}
