using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Bootstrap;
using Bootstrap.AutoMapper;
using Bootstrap.Extensions.StartupTasks;
using Motionless.Data.Persistence;
using Motionless.Deployment.Admin.App_Start;

namespace Motionless.Deployment.Admin
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			WebApiConfig.Register(GlobalConfiguration.Configuration);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			
			PersistenceHelper.UpdateDatabaseSchema();

			Bootstrapper.With.AutoMapper().And.StartupTasks().Start();
		}

		protected void Application_Error(Object sender, System.EventArgs e)
		{
			PersistenceHelper.ForceDispose();
		}
	}
}