using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Motionless.Deployment.Contracts.Data.Model;
using PagedList;

namespace Motionless.Deployment.Admin.Models
{
	public class BindingListViewModel
	{
		public StaticPagedList<IBinding> Bindings { get; set; }
	}
}