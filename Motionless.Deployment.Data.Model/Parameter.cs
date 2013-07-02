using Motionless.Data.Persistence;
using Motionless.Deployment.Contracts.Data.Model;

namespace Motionless.Deployment.Data.Model
{
	public class Parameter : BaseObject<Parameter>, IParameter
	{
		public virtual string Name { get; set; }
		public virtual string Value { get; set; }
	}
}
