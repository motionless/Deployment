using Motionless.Data.Persistence;

namespace Motionless.Deployment.Contracts.Data.Model
{
	public interface IWebsite : IBaseObject
	{
		IApplicationPool ApplicationPool { get; set; }
		string Name { get; set; }
		string PhysicalPath { get; set; }
		Iesi.Collections.Generic.ISet<IBinding> Bindings { get; set; }
		Iesi.Collections.Generic.ISet<IVirtualDirectory> VirtualDirectories { get; set; }
	}
}