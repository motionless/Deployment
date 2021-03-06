﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Motionless.Deployment.Contracts.Data.Model;
using PagedList;

namespace Motionless.Deployment.Admin.Models
{
	public class ProductListViewModel
	{
		public StaticPagedList<IProduct> Products { get; set; }
	}
}