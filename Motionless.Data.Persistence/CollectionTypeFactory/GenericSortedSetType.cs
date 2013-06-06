using System;
using System.Collections.Generic;

namespace Motionless.Data.Persistence.CollectionTypeFactory
{
	[Serializable]
	public class GenericSortedSetType<T> : GenericSetType<T>
	{
		private readonly IComparer<T> comparer;

		public GenericSortedSetType(string role, string propertyRef, IComparer<T> comparer)
			: base(role, propertyRef)
		{
			this.comparer = comparer;
		}

		public override object Instantiate(int anticipatedSize)
		{
			return new SortedSet<T>(this.comparer);
		}

		public IComparer<T> Comparer
		{
			get
			{
				return this.comparer;
			}
		}
	}
}