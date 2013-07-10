using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Motionless.Deployment.Contracts.Data.Model;

namespace Motionless.Deployment.Service
{
	public class DeploymentWorker
	{
		/// <summary>
		/// Deploy package run on every server that is part of the environment.
		/// The server knows its role and name. Deploy package is just the execution method to really install the package.
		/// </summary>
		/// <param name="package"></param>
		public void DeployPackage(IPackage package)
		{
			
		}
	}
}
