﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motionless.Data.Persistence
{
	public class SortProperties<T> : Dictionary<Func<BaseObject<T>, IComparable>, SortOrder> where T : BaseObject<T>
	{
	}
}
