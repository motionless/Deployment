using Motionless.Data.Persistence;

namespace Motionless.Deployment.Data.Model
{
	public class VirtualDirectory : BaseObject<VirtualDirectory>
	{
		public virtual string PhysicalPath{get;set;}
		public virtual string VirtualPath{get;set;}
	}
}
