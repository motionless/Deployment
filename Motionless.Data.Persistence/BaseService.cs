using System;
using System.Collections.Generic;
using System.Linq;
using Omu.ValueInjecter;

namespace Motionless.Data.Persistence
{
	public abstract class BaseService<T,TI> : IBaseService<TI> where T : BaseObject<T>, new()
		where TI : IBaseObject
	{
		
		/// <summary>
		/// Counts all elements dispite the deleted ones.
		/// </summary>
		/// <returns></returns>
		public long Count()
		{
			return this.Count(false); 
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


		/// <summary>
		/// Gets the by id.
		/// </summary>
		/// <param name="id">The id.</param>
		/// <returns></returns>
		public TI GetById(long id)
		{
			using (var pc = PersistenceHelper.CreatePersistenceContext())
			{
				return (TI) ((IBaseObject)BaseObject<T>.FindById(id));
			}
		}

		public IEnumerable<TI> GetAll()
		{
			long totalCount = 0;
			return this.GetAll(-1, -1, out totalCount);
		}

		/// <summary>
		/// Gets all.
		/// </summary>
		/// <param name="page">The page.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <param name="totalCount">The total count.</param>
		/// <returns></returns>
		public IEnumerable<TI> GetAll(int? page, int? pageSize, out long totalCount)
		{
			return this.GetAll(page, pageSize, false, out totalCount);
		}

		/// <summary>
		/// Gets all.
		/// </summary>
		/// <param name="page">The page.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <param name="includeDeleted">The include deleted.</param>
		/// <param name="totalCount">The total count.</param>
		/// <returns></returns>
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
					resultSet = resultSet.Where(o => !o.IsDeleted);
				}

				totalCount = resultSet.Count();
				if (page.Value >= 0 && pageSize.Value >= 0)
				{
					return (IEnumerable<TI>)resultSet.Skip(page.Value * pageSize.Value).Take(pageSize.Value);
				}
				else
				{
					return (IEnumerable<TI>)resultSet;
				}
			}
		}

		public IEnumerable<TI> GetAll(int? page, int? pageSize, bool? includeDeleted, IDictionary<Func<IBaseObject, IComparable>, SortOrder> sortProperties, out long totalCount)
		{
			totalCount = 0;
			using (var pc = PersistenceHelper.CreatePersistenceContext())
			{
				IQueryable<T> resultSet = BaseObject<T>.Queryable;

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
					resultSet = resultSet.Where(o => !o.IsDeleted);
				}

				if (sortProperties.Any())
				{
					IOrderedQueryable<T> sortedResultSet = null;

					KeyValuePair<Func<IBaseObject, IComparable>, SortOrder> firstCriteria = sortProperties.FirstOrDefault();
					if (firstCriteria.Key != null)
					{
						if (firstCriteria.Value == SortOrder.Ascending)
						{
							sortedResultSet = resultSet.OrderBy(element => firstCriteria.Key(element));
						}
						else if (firstCriteria.Value == SortOrder.Descending)
						{
							sortedResultSet = resultSet.OrderByDescending(element => firstCriteria.Key(element));
						}
						if (sortedResultSet != null && sortProperties.Count > 1)
						{
							for (int i = 1; i < sortProperties.Count; i++)
							{
								var sortProperty = sortProperties.ElementAt(i);
								if (sortProperty.Value == SortOrder.Ascending)
								{
									sortedResultSet = sortedResultSet.ThenBy(element => sortProperty.Key(element));
								}
								else if (sortProperty.Value == SortOrder.Descending)
								{
									sortedResultSet = sortedResultSet.ThenByDescending(element => sortProperty.Key(element));
								}
							}
						}

						resultSet = sortedResultSet;
					}
				}

				if (resultSet != null)
				{
					totalCount = resultSet.Count();
					return (IEnumerable<TI>)resultSet.Skip(page.Value * pageSize.Value).Take(pageSize.Value);
				}
				return null;
			}
		}

		public TI CreateInstance()
		{
			return (TI)((IBaseObject)new T());
		}

		/// <summary>
		/// Creates the specified base object interface.
		/// </summary>
		/// <param name="baseObjectInterface">The base object interface.</param>
		/// <returns></returns>
		public TI CreateOrUpdate(TI baseObjectInterface)
		{
			BaseObject<T> savedObject = null;
			using (var pc = PersistenceHelper.CreatePersistenceContext())
			{
				T baseObject = AutoMapper.Mapper.Map<TI, T>(baseObjectInterface);
				savedObject = baseObject.Merge();
			}
			return (TI)((IBaseObject)savedObject);
		}

		/// <summary>
		/// Deletes the specified base object interface.
		/// </summary>
		/// <param name="baseObjectInterface">The base object interface.</param>
		/// <returns></returns>
		public TI Delete(TI baseObjectInterface)
		{
			BaseObject<T> savedObject = null;
			using (var pc = PersistenceHelper.CreatePersistenceContext())
			{
				savedObject = BaseObject<T>.FindById(baseObjectInterface.Id);
				savedObject.IsDeleted = true;

			}
			return (TI)((IBaseObject)savedObject);
		}

		/// <summary>
		/// Deletes the physically.
		/// </summary>
		/// <param name="baseObjectInterface">The base object interface.</param>
		/// <returns></returns>
		public TI DeletePhysically(TI baseObjectInterface)
		{
			BaseObject<T> savedObject = null;
			using (var pc = PersistenceHelper.CreatePersistenceContext())
			{
				savedObject = BaseObject<T>.FindById(baseObjectInterface.Id);
				savedObject.Delete();
			}
			return (TI)((IBaseObject)savedObject);
		}
	}
}
