using System.Collections.Generic;
using NHibernate.Type;

namespace Motionless.Data.Persistence.CollectionTypeFactory
{
	public class Net4CollectionTypeFactory : DefaultCollectionTypeFactory
	{
		public override CollectionType Set<T>(string role, string propertyRef, bool embedded)
		{
			return new GenericSetType<T>(role, propertyRef);
		}

		public override CollectionType SortedSet<T>(string role, string propertyRef, bool embedded, IComparer<T> comparer)
		{
			return new GenericSortedSetType<T>(role, propertyRef, comparer);
		}
	}
}