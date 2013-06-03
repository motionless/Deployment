using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Linq;

namespace Motionless.Data.Persistence
{

	public abstract class BaseObject<T> : IBaseObject 
		where T : BaseObject<T>
	{
		/// <summary>
		/// Gets or sets the id.
		/// </summary>
		/// <value>
		/// The id.
		/// </value>
		public virtual long Id { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance is deleted.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance is deleted; otherwise, <c>false</c>.
		/// </value>
		public virtual bool IsDeleted { get; set; }

		/// <summary>
		/// Gets or sets the created at timestamp.
		/// </summary>
		/// <value>
		/// The created at.
		/// </value>
		public virtual DateTime CreatedAt { get; set; }

		/// <summary>
		/// Gets or sets the updated at timestamp.
		/// </summary>
		/// <value>
		/// The updated at.
		/// </value>
		public virtual DateTime UpdatedAt { get; set; }



		public static IQueryable<T> Queryable
		{
			get { return PersistenceHelper.SessionFactory.GetCurrentSession().Query<T>(); }
		}

		public static T FindById(long id)
		{
			return PersistenceHelper.SessionFactory.GetCurrentSession().Query<T>().FirstOrDefault(baseObject  => (baseObject).Id == id);
		}

		public static IQueryable<T> FindAll()
		{
			return PersistenceHelper.SessionFactory.GetCurrentSession().Query<T>();
		}
	}
}
