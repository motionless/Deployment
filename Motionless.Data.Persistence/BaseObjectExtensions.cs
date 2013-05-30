using System.Linq;
using NHibernate.Linq;

namespace Motionless.Data.Persistence
{
	public static class BaseObjectExtensions 
	{

		public static void Save<T>(this BaseObject<T> baseObject) where T : BaseObject<T>
		{
			PersistenceHelper.SessionFactory.GetCurrentSession().Save(baseObject);
		}

		public static void SaveOrUpdate<T>(this BaseObject<T> baseObject) where T : BaseObject<T>
		{
			PersistenceHelper.SessionFactory.GetCurrentSession().SaveOrUpdate(baseObject);
		}

		public static void Update<T>(this BaseObject<T> baseObject) where T : BaseObject<T>
		{
			PersistenceHelper.SessionFactory.GetCurrentSession().Update(baseObject);
		}

		public static void Merge<T>(this BaseObject<T> baseObject) where T : BaseObject<T>
		{
			PersistenceHelper.SessionFactory.GetCurrentSession().Merge(baseObject);
		}

		public static IQueryable<T> Queryable<T>(this T queryableObject) where T : BaseObject<T>
		{
			{ return PersistenceHelper.SessionFactory.GetCurrentSession().Query<T>(); }
		}
	}
}
