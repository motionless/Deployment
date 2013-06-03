using Motionless.Data.Persistence;
using Motionless.Deployment.Contracts.Data.Model;

namespace Motionless.Deployment.Data.Model
{
	public class VirtualDirectory : BaseObject<VirtualDirectory>, IVirtualDirectory
	{
		public virtual string PhysicalPath{get;set;}
		public virtual string VirtualPath{get;set;}
	}
}
