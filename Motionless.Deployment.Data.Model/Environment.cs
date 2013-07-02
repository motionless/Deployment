using System.Collections.Generic;
using Motionless.Data.Persistence;
using Motionless.Deployment.Contracts.Data.Model;
using Motionless.Deployment.Contracts.Enums;

namespace Motionless.Deployment.Data.Model
{
	public class Environment : BaseObject<Environment>, IEnvironment
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public virtual string Name { get; set; }

		/// <summary>
		/// Gets or sets the stage.
		/// </summary>
		/// <value>
		/// The stage.
		/// </value>
		public virtual Stage Stage { get; set; }

		/// <summary>
		/// Gets or sets the product.
		/// </summary>
		/// <value>
		/// The product.
		/// </value>
		public virtual IProduct Product { get; set; }

		/// <summary>
		/// Gets or sets the servers.
		/// </summary>
		/// <value>
		/// The servers.
		/// </value>
		public virtual ISet<IServer> Servers { get; set; }

		/// <summary>
		/// Gets or sets the parameters.
		/// </summary>
		/// <value>
		/// The parameters.
		/// </value>
		public virtual ISet<IParameter> Parameters { get; set; }
	}
}
