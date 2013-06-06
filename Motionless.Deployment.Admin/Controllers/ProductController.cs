using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Motionless.Data.Persistence;
using Motionless.Deployment.Admin.Models;
using Motionless.Deployment.Contracts.Data.Model;
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
			var pageNumber = (page ?? 1) - 1;
			long totalCount;
			IEnumerable<IProduct> products = ProductService.GetAll(pageNumber, 10, out totalCount);

			var pageInformation = new StaticPagedList<IProduct>(products, pageNumber + 1, 10, (int) totalCount);

			ViewBag.OnePageOfProducts = pageInformation;
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
			return View(new ProductViewModel());
		}

		/// <summary>
		/// Creates the specified product.
		/// </summary>
		/// <param name="productViewModel"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult Create(ProductViewModel productViewModel)
		{
			if (ModelState.IsValid)
			{
				var product = AutoMapper.Mapper.Map<ProductViewModel, IProduct>(productViewModel);
				ProductService.CreateOrUpdate(product);
			}
			else
			{
				return View(productViewModel);
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
				var product = ProductService.GetById(id.Value);
				return View(AutoMapper.Mapper.Map<IProduct, ProductViewModel>(product));
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
		public ActionResult Edit(int id, ProductViewModel productViewModel, int? page)
		{
			if (ModelState.IsValid)
			{
				var product = AutoMapper.Mapper.Map<ProductViewModel, IProduct>(productViewModel);
				ProductService.CreateOrUpdate(product);
				return RedirectToAction("Index",new {page});
			}
			return View(productViewModel);
		}

		/// <summary>
		/// Delete product specified by id.
		/// </summary>
		/// <param name="id">The id.</param>
		/// <param name="page">The page.</param>
		/// <returns></returns>
		public ActionResult Delete(int id, int? page)
		{
			var product = ProductService.GetById(id);
			if (product != null)
			{
				ProductService.Delete(product);
			}
			return RedirectToAction("Index",new {page}) ;
		}
	}
}
