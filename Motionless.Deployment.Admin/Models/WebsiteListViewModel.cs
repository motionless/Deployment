using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Motionless.Deployment.Contracts.Data.Model;
using PagedList;

namespace Motionless.Deployment.Admin.Models
{
	public class WebsiteListViewModel
	{
		public StaticPagedList<IWebsite> Websites { get; set; }
	}
}