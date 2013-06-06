using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Motionless.Deployment.Contracts.Data.Model;

namespace Motionless.Deployment.Admin.Models
{
	public class PackageViewModel : IPackage
	{
		public long Id { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public string Name { get; set; }
		public Version Version { get; set; }
		public string PackageUrl { get; set; }
		public ISet<IWebsite> Websites { get; set; }
		public IProduct Product { get; set; }
		public ISet<ISetupStep> SetupSteps { get; set; }
	}
}