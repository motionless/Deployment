using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PagedList;

namespace Motionless.Deployment.Admin.Controllers
{
    public class ServerController : Controller
    {
        //
        // GET: /Server/

        public ActionResult Index(int? page)
        {
			var pageNumber = page ?? 1;

			var servers = Data.Model.Server.Queryable.ToPagedList(pageNumber, 10); // will only contain 25 products max because of the pageSize

			ViewBag.Servers = servers;

			return View();
        }

        //
        // GET: /Server/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Server/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Server/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Server/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Server/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Server/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Server/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
