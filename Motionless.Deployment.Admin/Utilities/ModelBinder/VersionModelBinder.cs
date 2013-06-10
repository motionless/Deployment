using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Motionless.Deployment.Admin.Utilities.ModelBinder
{
	public class VersionModelBinder : IModelBinder
	{
		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			if (controllerContext == null)
			{
				throw new ArgumentNullException("controllerContext");
			}
			if (bindingContext == null)
			{
				throw new ArgumentNullException("bindingContext");
			}

			NameValueCollection collection = controllerContext.RequestContext.HttpContext.Request.Form;

			int major, minor, build, revision;

			int.TryParse(collection[bindingContext.ModelName + ".Major"], out major);
			int.TryParse(collection[bindingContext.ModelName + ".Minor"], out minor);
			int.TryParse(collection[bindingContext.ModelName + ".Build"], out build);
			int.TryParse(collection[bindingContext.ModelName + ".Revision"], out revision);

			Version returnValue = new Version(major, minor, build, revision);

			return returnValue;
		}
	}
}
