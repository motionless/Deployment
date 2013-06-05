using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Motionless.Deployment.Contracts.Services;
using Motionless.Deployment.Services;

namespace Motionless.Deployment.Admin.Controllers
{
	[Export]
	[PartCreationPolicy(CreationPolicy.NonShared)]
    public class BaseController : Controller
    {
		[Import(typeof(IProductService))]
		public IProductService ProductService { get; set; }

		[Import(typeof(IEnvironmentService))]
		public IEnvironmentService EnvironmentService { get; set; }

		[Import(typeof(IPackageService))]
		public IPackageService PackageService { get; set; }
    }
}
