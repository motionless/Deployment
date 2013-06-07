using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Motionless.Deployment.Contracts.Data.Model;
using PagedList;

namespace Motionless.Deployment.Admin.Models
{
	public class PackageListViewModel
	{
		public StaticPagedList<IPackage> Packages { get; set; }
	}
}