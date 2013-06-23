using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Motionless.Deployment.Contracts.Data.Model;

namespace Motionless.Deployment.Admin.Models
{
	public class ApplicationPoolViewModel : IApplicationPool
	{
		public long Id { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		
		public string Name { get; set; }
		
		public string ManagedRuntimeVersion { get; set; }
		
		public string Identity { get; set; }
		public string IdentityPassword { get; set; }
		
		public bool Enable32BitAppOnWin64 { get; set; }
		
		[Range(typeof(int), "0", "10080")]
		public int IdleTimeout { get; set; }
		public int PeriodicRestartTime { get; set; }
		
		[Range(typeof(int),"1","2048")]
		public int MaxProcesses { get; set; }
	}
}