using Motionless.Data.Persistence;
using Motionless.Deployment.Contracts.Data.Model;

namespace Motionless.Deployment.Data.Model
{
	public class Parameter : BaseObject<Parameter>, IParameter
	{
		public virtual string Name { get; set; }
		public virtual string Value { get; set; }

		/// <summary>
		/// Gets or sets the owner of the parameter this could by any class that implements the interface IParametrizable.
		/// </summary>
		/// <value>
		/// The owner.
		/// </value>
		public virtual IParametrizable Owner { get; set; }
	}
}
