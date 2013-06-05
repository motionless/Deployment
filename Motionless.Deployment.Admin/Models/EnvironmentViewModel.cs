using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Motionless.Deployment.Contracts.Data.Model;
using Motionless.Deployment.Contracts.Enums;

namespace Motionless.Deployment.Admin.Models
{
	public class EnvironmentViewModel : IEnvironment
	{
		public long Id { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public string Name { get; set; }
		public Stage Stage { get; set; }
		public IProduct Product { get; set; }
		public Iesi.Collections.Generic.ISet<IServer> Servers { get; set; }
	}
}