using System.Collections.Generic;
using Motionless.Data.Persistence;

namespace Motionless.Deployment.Contracts.Data.Model
{
	public interface IWebsite : IBaseObject
	{
		IApplicationPool ApplicationPool { get; set; }
		string Name { get; set; }
		string PhysicalPath { get; set; }
		ISet<IBinding> Bindings { get; set; }
		ISet<IVirtualDirectory> VirtualDirectories { get; set; }
	}
}