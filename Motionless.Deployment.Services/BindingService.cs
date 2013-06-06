using System.ComponentModel.Composition;
using Motionless.Data.Persistence;
using Motionless.Deployment.Contracts.Data.Model;
using Motionless.Deployment.Contracts.Services;

namespace Motionless.Deployment.Services
{
	[Export(typeof(IBindingService))]
	public class BindingService : BaseService<Data.Model.Binding,IBinding>, IBindingService
	{
		
	}
}