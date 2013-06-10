using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Motionless.Data.Persistence;
using Motionless.Deployment.Contracts.Data.Model;

namespace Motionless.Deployment.Data.Model
{
	public class PackageConfiguration : BaseObject<PackageConfiguration>, IPackageConfiguration
	{
		public virtual string Name { get; set; }
		public virtual Version Version { get; set; }
		public virtual bool IsActive { get; set; }
		public virtual ISet<IPackage> Packages { get; set; }
		public virtual IProduct Product { get; set; }
		public virtual string SearchPath { get; set; }
		public virtual string SearchPattern { get; set; }
	}
}
