using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Motionless.Data.Persistence.Test.Model;

namespace Motionless.Data.Persistence.Test
{
	[TestClass]
	public class PersistenceHelperTests
	{
		[ClassInitialize]
		public static void ClassInitialize(TestContext context)
		{
			//PersistenceHelper.CreateDatabaseSchema();
			PersistenceHelper.UpdateDatabaseSchema();
		}

		[TestMethod]
		public void CreatePersistenceContext()
		{
			using (var persistenceContext = PersistenceHelper.CreatePersistenceContext())
			{
				Assert.IsNotNull(persistenceContext);
			}
		}

		[TestMethod]
		public void CreateRootEntity()
		{
			using (var persistenceContext = PersistenceHelper.CreatePersistenceContext())
			{
				RootEntity rootEntity = new RootEntity();
				rootEntity.Name = "First Root Entity";

				rootEntity.SaveOrUpdate();
			}
		}

		[TestMethod]
		public void CreateChildren()
		{
			using (var pc = PersistenceHelper.CreatePersistenceContext())
			{
				var rootEntry = RootEntity.Queryable.FirstOrDefault();

				if (rootEntry == null)
				{
					CreateRootEntity();
					rootEntry = RootEntity.Queryable.FirstOrDefault();
				}

				if (rootEntry != null)
				{
					for (int i = 0; i < 5; i++)
					{
						ChildEntity childEntity = new ChildEntity();
						childEntity.Name = string.Format("ChildEntry {0}", i + 1);
						childEntity.RootEntity = rootEntry;
						childEntity.SaveOrUpdate();
					}
				}
				
				
			}
		}
	}
}
