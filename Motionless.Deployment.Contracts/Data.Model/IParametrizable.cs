using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motionless.Deployment.Contracts.Data.Model
{
	public interface IParametrizable
	{
		/// <summary>
		/// Gets or sets the parameters.
		/// </summary>
		/// <value>
		/// The parameters.
		/// </value>
		ISet<IParameter> Parameters { get; set; }
	}
}
