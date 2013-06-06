using System.Linq;
using System.Web.Mvc;
using Motionless.Data.Persistence;
using Motionless.Deployment.Data.Model;
using PagedList;

namespace Motionless.Deployment.Admin.Controllers
{
	public class ProductController : BaseController
	{
		/// <summary>
		/// List the specified page.
		/// </summary>
		/// <param name="page">The page.</param>
		/// <returns></returns>
		public ActionResult Index(int? page)
		{
			var pageNumber = page ?? 1;
			//var onePageOfProducts =  ProductService.   // Product.Queryable.ToPagedList(pageNumber, 10); // will only contain 25 products max because of the pageSize
			ProductService.

			ViewBag.OnePageOfProducts = onePageOfProducts;
			return View();
		}

		/// <summary>
		/// Detailses product by the specified id.
		/// </summary>
		/// <param name="id">The id.</param>
		/// <returns></returns>
		public ActionResult Details(int id)
		{
			return View(Product.FindById(id));
		}

		/// <summary>
		/// Creates this instance.
		/// </summary>
		/// <returns></returns>
		public ActionResult Create()
		{
			return View();
		}

		/// <summary>
		/// Creates the specified product.
		/// </summary>
		/// <param name="product">The product.</param>
		/// <returns></returns>
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

		/// <summary>
		/// Edits the specified id.
		/// </summary>
		/// <param name="id">The id.</param>
		/// <returns></returns>
		public ActionResult Edit(int? id)
		{
			if (id.HasValue)
			{
				return View(Product.FindById(id.Value));
			}
			return RedirectToAction("Create");
		}


		/// <summary>
		/// Save the changed product.
		/// </summary>
		/// <param name="id">The id.</param>
		/// <param name="product">The product.</param>
		/// <param name="page">The page.</param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult Edit(int id, Product product, int? page)
		{
			if (ModelState.IsValid)
			{
				product.SaveOrUpdate();
				return RedirectToAction("Index",new {page});
			}
			return View(product);
		}

		/// <summary>
		/// Delete product specified by id.
		/// </summary>
		/// <param name="id">The id.</param>
		/// <param name="page">The page.</param>
		/// <returns></returns>
		public ActionResult Delete(int id, int? page)
		{
			var product = Product.FindById(id);
			if (product != null)
			{
				product.Delete();
			}
			return RedirectToAction("Index",new {page}) ;
		}
	}
}
