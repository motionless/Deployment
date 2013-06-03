using Motionless.Data.Persistence;

namespace Motionless.Deployment.Contracts.Data.Model
{
	public interface IVirtualDirectory : IBaseObject
	{
		string PhysicalPath { get; set; }
		string VirtualPath { get; set; }
	}
}