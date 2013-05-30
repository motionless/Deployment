using System.Web.Mvc;
using Motionless.Deployment.Admin.Filters;

namespace Motionless.Deployment.Admin.App_Start
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new PersistenceContextFilter());
			filters.Add(new HandleErrorAttribute());
		}
	}
}