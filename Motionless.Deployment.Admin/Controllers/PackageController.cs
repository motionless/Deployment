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
	public class PackageController : BaseController
	{
		/// <summary>
		/// List the specified page.
		/// </summary>
		/// <param name="page">The page.</param>
		/// <returns></returns>
		public ActionResult Index(int? page)
		{
			var viewModel = new PackageListViewModel();
			
			var pageNumber = (page ?? 1) - 1;
			long totalCount;
			IEnumerable<IPackage> packages = PackageService.GetAll(pageNumber, PageSize, out totalCount);

			viewModel.Packages = new StaticPagedList<IPackage>(packages, pageNumber + 1, PageSize, (int)totalCount);
			return View(viewModel);
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
			var viewModel = new PackageViewModel();
			viewModel.Products = ProductService.GetAll().ToList();
			viewModel.PackageConfigurations = PackageConfigurationService.GetAll().ToList();
			return View(viewModel);
		}

		/// <summary>
		/// Creates the specified product.
		/// </summary>
		/// <param name="productViewModel"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult Create(PackageViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var package = AutoMapper.Mapper.Map<PackageViewModel, IPackage>(viewModel);
				if (viewModel.SelectedProductId > 0)
				{
					package.Product = ProductService.GetById(viewModel.SelectedProductId);
				}
				if (viewModel.SelectedPackageConfigurationId > 0)
				{
					package.PackageConfiguration = PackageConfigurationService.GetById(viewModel.SelectedPackageConfigurationId);
				}

				PackageService.CreateOrUpdate(package);
			}
			else
			{
				return View(viewModel);
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
				var package = PackageService.GetById(id.Value);
				var viewModel = AutoMapper.Mapper.Map<IPackage, PackageViewModel>(package);
				viewModel.Products = ProductService.GetAll().ToList();
				viewModel.PackageConfigurations = PackageConfigurationService.GetAll().ToList();
				if (viewModel.Product != null)
				{
					viewModel.SelectedProductId = viewModel.Product.Id;
					viewModel.SelectedPackageConfigurationId= viewModel.PackageConfiguration.Id;
				}
				return View(viewModel);
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
		public ActionResult Edit(PackageViewModel viewModel, int? page)
		{
			if (ModelState.IsValid && viewModel.SelectedProductId > 0 && viewModel.SelectedPackageConfigurationId > 0)
			{
				var package = AutoMapper.Mapper.Map<PackageViewModel, IPackage>(viewModel);
				if (viewModel != null)
				{
					if (viewModel.SelectedProductId > 0)
					{
						package.Product = ProductService.GetById(viewModel.SelectedProductId);
					}
					if (viewModel.SelectedPackageConfigurationId > 0)
					{
						package.PackageConfiguration = PackageConfigurationService.GetById(viewModel.SelectedPackageConfigurationId);
					}
				}
				PackageService.CreateOrUpdate(package);
				return RedirectToAction("Index", new { page });
			}
			return View(viewModel);

		}

		/// <summary>
		/// Delete product specified by id.
		/// </summary>
		/// <param name="id">The id.</param>
		/// <param name="page">The page.</param>
		/// <returns></returns>
		public ActionResult Delete(int id, int? page)
		{
			var package = PackageService.GetById(id);
			if (package != null)
			{
				PackageService.Delete(package);
			}
			return RedirectToAction("Index",new {page}) ;
		}
	}
}
