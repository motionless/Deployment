using System.Web.Mvc;
using Motionless.Data.Persistence;

namespace Motionless.Deployment.Admin.Filters
{
	public class PersistenceContextFilter : ActionFilterAttribute
	{
		private PersistenceContext persistenceContext;

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			persistenceContext = PersistenceHelper.CreatePersistenceContext();
			base.OnActionExecuting(filterContext);
		}

		public override void OnResultExecuted(ResultExecutedContext filterContext)
		{
			base.OnResultExecuted(filterContext);
			persistenceContext.Dispose();
		}
	}
}