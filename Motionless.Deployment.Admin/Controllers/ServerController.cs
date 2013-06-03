using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Motionless.Data.Persistence;
using Motionless.Deployment.Data.Model;
using PagedList;

namespace Motionless.Deployment.Admin.Controllers
{
    public class ServerController : Controller
    {
        public ActionResult Index(int? page)
        {
			var pageNumber = page ?? 1;
			var servers = Data.Model.Server.Queryable.ToPagedList(pageNumber, 10); // will only contain 25 products max because of the pageSize
			ViewBag.Servers = servers;
			return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Server server)
        {
	        if (ModelState.IsValid)
			{
				server.SaveOrUpdate();
				return RedirectToAction("Index");
			}
	        return View(server);
        }

	    public ActionResult Edit(int? id, int? page)
	    {
		    if (id.HasValue)
		    {
			    return View(Data.Model.Server.FindById(id.Value));
		    }
		    return RedirectToAction("Create");
	    }

        [HttpPost]
        public ActionResult Edit(int id, Server server, int? page)
        {
            try
            {
                server.SaveOrUpdate();
                return RedirectToAction("Index",new {page});
            }
            catch
            {
                return View(server);
            }
        }

        public ActionResult Delete(int id, int? page)
        {
	        var server = Data.Model.Server.FindById(id);
	        if (server != null)
	        {
		        server.Delete();
	        }

            return RedirectToAction("Index", new {page});
        }
    }
}
