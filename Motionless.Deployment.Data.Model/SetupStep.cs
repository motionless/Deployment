using Motionless.Data.Persistence;
using Motionless.Deployment.Contracts.Data.Model;

namespace Motionless.Deployment.Data.Model
{
	public class SetupStep : BaseObject<SetupStep>, ISetupStep
	{
		public virtual IPackage Package { get; set; }

		public virtual string Name { get; set; }
		public virtual int Order { get; set; }


	}
}
