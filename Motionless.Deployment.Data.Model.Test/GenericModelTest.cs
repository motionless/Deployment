using Microsoft.VisualStudio.TestTools.UnitTesting;
using Motionless.Data.Persistence;

namespace Motionless.Deployment.Data.Model.Test
{
	[TestClass]
	public class GenericModelTest
	{
		[TestMethod]
		public void LoadModelMapping()
		{
			PersistenceHelper.CreateDatabaseSchema();
			using (var pc = PersistenceHelper.CreatePersistenceContext())
			{
				
			}
		}
	}
}
