using System;
using System.Collections.Generic;

namespace Motionless.Data.Persistence
{
	public interface IBaseService<TI>// where T : BaseObject where TI : IBaseObject
	{
		/// <summary>
		/// Counts all elements dispite the deleted ones.
		/// </summary>
		/// <returns></returns>
		long Count();

		/// <summary>
		/// Counts all elements - include deleted if includeDeleted is true.
		/// </summary>
		/// <param name="includeDeleted">if set to <c>true</c> [include deleted].</param>
		/// <returns></returns>
		long Count(bool includeDeleted);

		/// <summary>
		/// Gets the by id.
		/// </summary>
		/// <param name="id">The id.</param>
		/// <returns></returns>
		TI GetById(long id);

		/// <summary>
		/// Gets all.
		/// </summary>
		/// <returns></returns>
		IEnumerable<TI> GetAll();

		/// <summary>
		/// Gets all.
		/// </summary>
		/// <param name="page">The page.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <param name="totalCount">The total count.</param>
		/// <returns></returns>
		IEnumerable<TI> GetAll(int? page, int? pageSize, out long totalCount);

		/// <summary>
		/// Gets all.
		/// </summary>
		/// <param name="page">The page.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <param name="includeDeleted">The include deleted.</param>
		/// <param name="totalCount">The total count.</param>
		/// <returns></returns>
		IEnumerable<TI> GetAll(int? page, int? pageSize, bool? includeDeleted, out long totalCount);

		IEnumerable<TI> GetAll(int? page, int? pageSize, bool? includeDeleted,IDictionary<Func<IBaseObject, IComparable>,SortOrder> sortProperties, out long totalCount);

		/// <summary>
		/// Creates the specified base object interface.
		/// </summary>
		/// <param name="baseObjectInterface">The base object interface.</param>
		/// <returns></returns>
		TI CreateOrUpdate(TI baseObjectInterface);

		/// <summary>
		/// Deletes the specified base object interface.
		/// </summary>
		/// <param name="baseObjectInterface">The base object interface.</param>
		/// <returns></returns>
		TI Delete(TI baseObjectInterface);

		/// <summary>
		/// Deletes the physically.
		/// </summary>
		/// <param name="baseObjectInterface">The base object interface.</param>
		/// <returns></returns>
		TI DeletePhysically(TI baseObjectInterface);
	}
}