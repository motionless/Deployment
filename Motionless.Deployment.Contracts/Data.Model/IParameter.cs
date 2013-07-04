
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Motionless.Data.Persistence;

namespace Motionless.Deployment.Contracts.Data.Model
{
	public interface IParameter : IBaseObject
	{
		string Name { get; set; }
		string Value { get; set; }
	}
}
