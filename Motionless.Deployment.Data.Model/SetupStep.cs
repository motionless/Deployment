using Motionless.Data.Persistence;

namespace Motionless.Deployment.Data.Model
{
	public class SetupStep : BaseObject<SetupStep>
	{
		public virtual Package Package { get; set; }

		public virtual string Name { get; set; }
		public virtual int Order { get; set; }


	}
}
