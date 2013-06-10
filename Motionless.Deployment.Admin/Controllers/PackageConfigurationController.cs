using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Motionless.Data.Persistence;
using Motionless.Deployment.Admin.Models;
using Motionless.Deployment.Contracts.Data.Model;
using Motionless.Deployment.Data.Model;
using Motionless.Deployment.Services;
using PagedList;

namespace Motionless.Deployment.Admin.Controllers
{
	public class PackageConfigurationController : BaseController
	{
		/// <summary>
		/// List the specified page.
		/// </summary>
		/// <param name="page">The page.</param>
		/// <returns></returns>
		public ActionResult Index(int? page)
		{
			var viewModel = new PackageConfigurationListViewModel();
			
			var pageNumber = (page ?? 1) - 1;
			long totalCount;
			IEnumerable<IPackageConfiguration> packageConfigurations = PackageConfigurationService.GetAll(pageNumber, PageSize, out totalCount);

			viewModel.PackageConfigurations = new StaticPagedList<IPackageConfiguration>(packageConfigurations, pageNumber + 1, PageSize, (int)totalCount);
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
			return View(new PackageConfigurationViewModel());
		}

		/// <summary>
		/// Creates the specified product.
		/// </summary>
		/// <param name="viewModel"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult Create(PackageConfigurationViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var packageConfiguration = AutoMapper.Mapper.Map<PackageConfigurationViewModel, IPackageConfiguration>(viewModel);
				PackageConfigurationService.CreateOrUpdate(packageConfiguration);
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
				var packageConfiguration = PackageConfigurationService.GetById(id.Value);
				return View(AutoMapper.Mapper.Map<IPackageConfiguration, PackageConfigurationViewModel>(packageConfiguration));
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
		public ActionResult Edit(PackageConfigurationViewModel viewModel, int? page)
		{
			if (ModelState.IsValid)
			{
				var packageConfiguration = AutoMapper.Mapper.Map<PackageConfigurationViewModel, IPackageConfiguration>(viewModel);
				PackageConfigurationService.CreateOrUpdate(packageConfiguration);
				return RedirectToAction("Index",new {page});
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
			var packageConfiguration = PackageConfigurationService.GetById(id);
			if (packageConfiguration != null)
			{
				PackageConfigurationService.Delete(packageConfiguration);
			}
			return RedirectToAction("Index",new {page}) ;
		}
	}
}
