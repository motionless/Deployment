using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Motionless.Data.Persistence;
using PagedList;

namespace Motionless.Deployment.Admin.Controllers
{
	public class EnvironmentController : BaseController
	{
		public ActionResult Index(int? page)
		{
			var pageNumber = page ?? 1;
			var environments = Data.Model.Environment.Queryable.ToPagedList(pageNumber, 10); // will only contain 25 products max because of the pageSize
			ViewBag.Environments = environments;
			return View();
		}

		public ActionResult Details(int id)
		{
			return View();
		}

		public ActionResult Create()
		{
			return View(new Data.Model.Environment());
		}

		[HttpPost]
		public ActionResult Create(Data.Model.Environment environment)
		{
			if (ModelState.IsValid)
			{
				environment.SaveOrUpdate();
				return RedirectToAction("Index");
			}
			return View(environment);
		}

		public ActionResult Edit(int? id, int? page)
		{
			if (id.HasValue)
			{
				return View(Data.Model.Environment.FindById(id.Value));
			}
			return RedirectToAction("Create");
		}

		[HttpPost]
		public ActionResult Edit(int id, Data.Model.Environment environment , int? page)
		{
			try
			{
				environment.SaveOrUpdate();
				return RedirectToAction("Index", new { page });
			}
			catch
			{
				return View(environment);
			}
		}

		public ActionResult Delete(int id, int? page)
		{
			var environment = Data.Model.Environment.FindById(id);
			if (environment != null)
			{
				environment.Delete();
			}

			return RedirectToAction("Index", new { page });
		}
	}
}
