using System.Collections.Generic;
using System.Linq;
using Motionless.Data.Persistence;

namespace Motionless.Deployment.Services
{
	public class BaseService<T,TI> 
		where T : BaseObject<T>
		where TI : IBaseObject
	{
		/// <summary>
		/// Counts all elements dispite the deleted ones.
		/// </summary>
		/// <returns></returns>
		public long Count()
		{
			return Count(false); 
		}

		/// <summary>
		/// Counts all elements - include deleted if includeDeleted is true.
		/// </summary>
		/// <param name="includeDeleted">if set to <c>true</c> [include deleted].</param>
		/// <returns></returns>
		public long Count(bool includeDeleted)
		{
			var resultSet = BaseObject<T>.Queryable;
			if (!includeDeleted)
			{
				resultSet = resultSet.Where(o => !o.IsDeleted);
			}
			return resultSet.Count();
		}
		
		
		public TI GetById(long id)
		{
			using (var pc = PersistenceHelper.CreatePersistenceContext())
			{
				return (TI) ((IBaseObject)BaseObject<T>.FindById(id));
			}
		}

		public IEnumerable<TI> GetAll(int? page, int? pageSize, out long totalCount)
		{
			return GetAll(page, pageSize, false, out totalCount);
		}
		
		public IEnumerable<TI> GetAll(int? page, int? pageSize, bool? includeDeleted, out long totalCount)
		{
			using (var pc = PersistenceHelper.CreatePersistenceContext())
			{
				var resultSet = BaseObject<T>.Queryable;

				if (!page.HasValue)
				{
					page = 0;
				}
				if (!pageSize.HasValue)
				{
					pageSize = 10;
				}
				if (includeDeleted.HasValue && !includeDeleted.Value)
				{
					resultSet = resultSet.Where(o => o.IsDeleted);
				}

				totalCount = resultSet.Count();
				return (IEnumerable<TI>) resultSet.Skip(page.Value*pageSize.Value).Take(pageSize.Value);
			}
		}

		public TI Create(TI baseObjectInterface)
		{
			BaseObject<T> savedObject = null;
			using (var pc = PersistenceHelper.CreatePersistenceContext())
			{
				T baseObject = AutoMapper.Mapper.Map<TI, T>(baseObjectInterface);
				savedObject = baseObject.Merge();
			}
			return (TI)((IBaseObject)savedObject);
		}
	}
}
