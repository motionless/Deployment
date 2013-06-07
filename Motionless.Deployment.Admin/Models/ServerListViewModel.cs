using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Motionless.Deployment.Contracts.Data.Model;
using PagedList;

namespace Motionless.Deployment.Admin.Models
{
	public class ServerListViewModel
	{
		public StaticPagedList<IServer> Servers { get; set; }
	}
}