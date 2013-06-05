using System.ComponentModel.Composition;
using Motionless.Data.Persistence;
using Motionless.Deployment.Contracts.Data.Model;
using Motionless.Deployment.Data.Model;

namespace Motionless.Deployment.Services
{
	[Export(typeof(IPackageService))]
	public class PackageService : BaseService<Package, IPackage>, IPackageService
	{
		
	}
}
