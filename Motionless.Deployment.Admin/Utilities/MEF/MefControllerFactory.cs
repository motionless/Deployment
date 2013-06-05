using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Motionless.Deployment.Admin.Utilities.MEF
{
	
		public class MefControllerFactory : DefaultControllerFactory
		{
			private CompositionContainer Container { get; set; }

			public MefControllerFactory()
			{
				var catalog = new AggregateCatalog(new DirectoryCatalog("bin"));
				this.Container = new CompositionContainer(catalog);
			}

			public override IController CreateController(RequestContext requestContext, string controllerName)
			{
				var controller = base.CreateController(requestContext, controllerName);
				Container.SatisfyImportsOnce(controller);

				return controller;
			}

		}
	
}