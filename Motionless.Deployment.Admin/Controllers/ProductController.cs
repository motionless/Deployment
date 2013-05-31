using System.Linq;
using System.Web.Mvc;
using Motionless.Data.Persistence;
using Motionless.Deployment.Data.Model;
using PagedList;

namespace Motionless.Deployment.Admin.Controllers
{
	public class ProductController : Controller
	{
		//
		// GET: /Product/

		public ActionResult Index(int? page)
		{
			var pageNumber = page ?? 1;

			var onePageOfProducts = Product.Queryable.ToPagedList(pageNumber, 10); // will only contain 25 products max because of the pageSize

			ViewBag.OnePageOfProducts = onePageOfProducts;

			return View();
		}

		//
		// GET: /Product/Details/5

		public ActionResult Details(int id)
		{
			return View(Product.FindById(id));
		}

		//
		// GET: /Product/Create

		public ActionResult Create()
		{
			return View();
		}

		//
		// POST: /Product/Create

		[HttpPost]
		public ActionResult Create(Product product)
		{
			if (ModelState.IsValid)
			{
				product.SaveOrUpdate();
			}
			else
			{
				return View(product);
			}

			return RedirectToAction("Index");

		}

		//
		// GET: /Product/Edit/5

		public ActionResult Edit(int? id)
		{
			if (id.HasValue)
			{
				return View(Product.FindById(id.Value));
			}
			else
			{
				return RedirectToAction("Create");
			}
			
		}

		//
		// POST: /Product/Edit/5

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
		// GET: /Product/Delete/5

		public ActionResult Delete(int id, int? page)
		{
			var product = Product.Queryable.Where(p => p.Id == id).FirstOrDefault();
			product.Delete();
			return this.Index(page);
		}

		//
		// POST: /Product/Delete/5

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
