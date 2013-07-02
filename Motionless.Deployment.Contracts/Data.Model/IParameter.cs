
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motionless.Deployment.Contracts.Data.Model
{
	public interface IParameter
	{
		string Name { get; set; }
		string Value { get; set; }
	}
}
