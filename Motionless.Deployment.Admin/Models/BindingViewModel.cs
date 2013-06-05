using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Motionless.Deployment.Contracts.Data.Model;

namespace Motionless.Deployment.Admin.Models
{
	public class BindingViewModel : IBinding
	{
		public long Id { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public IWebsite Website { get; set; }
		public string Protocol { get; set; }
		public string IPAddress { get; set; }
		public int Port { get; set; }
		public string Hostname { get; set; }
		public string SslThumbPrint { get; set; }
	}
}