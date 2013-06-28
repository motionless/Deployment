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
		public int PageSize
		{
			get { return 10; }
		}

		[Import(typeof(IProductService))]
		public IProductService ProductService { get; set; }

		[Import(typeof(IEnvironmentService))]
		public IEnvironmentService EnvironmentService { get; set; }

		[Import(typeof(IPackageService))]
		public IPackageService PackageService { get; set; }

		[Import(typeof(IServerService))]
		public IServerService ServerService { get; set; }

		[Import(typeof(IWebsiteService))]
		public IWebsiteService WebsiteService { get; set; }

		[Import(typeof(IPackageConfigurationService))]
		public IPackageConfigurationService PackageConfigurationService { get; set; }

		[Import(typeof(IApplicationPoolService))]
		public IApplicationPoolService ApplicationPoolService { get; set; }

		[Import(typeof(IBindingService))]
		public IBindingService BindingService { get; set; }
    }
}
