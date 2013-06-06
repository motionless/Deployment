using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motionless.Data.Persistence.Test.Model
{
	public class RootEntity : BaseObject<RootEntity>
	{
		public virtual string Name { get; set; }
		public virtual ISet<ChildEntity> Children { get; set; }
	}
}
