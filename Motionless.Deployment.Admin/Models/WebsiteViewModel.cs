using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Motionless.Deployment.Contracts.Data.Model;

namespace Motionless.Deployment.Admin.Models
{
	public class WebsiteViewModel : IWebsite
	{
		public long Id { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public IApplicationPool ApplicationPool { get; set; }
		public string Name { get; set; }
		public string PhysicalPath { get; set; }
		public Iesi.Collections.Generic.ISet<IBinding> Bindings { get; set; }
		public Iesi.Collections.Generic.ISet<IVirtualDirectory> VirtualDirectories { get; set; }
	}
}