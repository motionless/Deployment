using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motionless.Data.Persistence.Test.Model
{
	public class ChildEntity : BaseObject<ChildEntity>
	{
		public virtual string Name { get; set; }
		public virtual RootEntity RootEntity { get; set; }
		public virtual int Order { get; set; }
	}
}
