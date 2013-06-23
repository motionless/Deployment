using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Motionless.Data.Persistence;
using Motionless.Deployment.Admin.Models;
using Motionless.Deployment.Contracts.Data.Model;
using Motionless.Deployment.Data.Model;
using PagedList;

namespace Motionless.Deployment.Admin.Controllers
{
	public class WebsiteController : BaseController
	{
		public ActionResult Index(int? page)
		{
			var viewModel = new WebsiteListViewModel();

			var pageNumber = (page ?? 1) - 1;
			long totalCount;
			IEnumerable<IWebsite> websites = WebsiteService.GetAll(pageNumber, PageSize, out totalCount);

			viewModel.Websites = new StaticPagedList<IWebsite>(websites, pageNumber + 1, PageSize, (int)totalCount);
			return View(viewModel);
		}

		public ActionResult Details(int id)
		{
			return View();
		}

		public ActionResult Create()
		{
			var viewModel = new WebsiteViewModel();
			viewModel.PackageConfigurations = PackageConfigurationService.GetAll().ToList();

			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Create(WebsiteViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var website = AutoMapper.Mapper.Map<WebsiteViewModel, IWebsite>(viewModel);
				if (viewModel.SelectedPackageConfigurationId > 0)
				{
					website.PackageConfiguration = PackageConfigurationService.GetById(viewModel.SelectedPackageConfigurationId);

					var appPool =AutoMapper.Mapper.Map<ApplicationPoolViewModel, IApplicationPool>(viewModel.ApplicationPool as ApplicationPoolViewModel);
					
					website.ApplicationPool = ApplicationPoolService.CreateOrUpdate(appPool);
				}

				WebsiteService.CreateOrUpdate(website);				
			}
			else
			{
				viewModel.PackageConfigurations = PackageConfigurationService.GetAll().ToList();
				return View(viewModel);
			}
			return RedirectToAction("Index");
			
		}

		public ActionResult Edit(int? id, int? page)
		{
			if (id.HasValue)
			{
				var viewModel = AutoMapper.Mapper.Map<IWebsite, WebsiteViewModel>(WebsiteService.GetById(id.Value));
				viewModel.PackageConfigurations = PackageConfigurationService.GetAll().ToList();
				if (viewModel.ApplicationPool == null)
				{
					viewModel.ApplicationPool = new ApplicationPoolViewModel();
				}
				else
				{
					viewModel.ApplicationPool = AutoMapper.Mapper.Map<IApplicationPool, ApplicationPoolViewModel>(viewModel.ApplicationPool);
				}

				return View(viewModel);
			}
			return RedirectToAction("Create");
		}

		[HttpPost]
		public ActionResult Edit(WebsiteViewModel viewModel, int? page)
		{
			if (ModelState.IsValid)
			{
				var website = AutoMapper.Mapper.Map<WebsiteViewModel, IWebsite>(viewModel);
				if (viewModel.SelectedPackageConfigurationId > 0)
				{
					website.PackageConfiguration = PackageConfigurationService.GetById(viewModel.SelectedPackageConfigurationId);

					var appPool = AutoMapper.Mapper.Map<ApplicationPoolViewModel, IApplicationPool>(viewModel.ApplicationPool as ApplicationPoolViewModel);

					website.ApplicationPool = ApplicationPoolService.CreateOrUpdate(appPool);
				}
				WebsiteService.CreateOrUpdate(website);
			}
			else
			{
				viewModel.PackageConfigurations = PackageConfigurationService.GetAll().ToList();
				return View(viewModel);
			}

			return RedirectToAction("Index");
		}

		public ActionResult Delete(int id, int? page)
		{
			var website = WebsiteService.GetById(id);
			if (website != null)
			{
				WebsiteService.Delete(website);
			}

			return RedirectToAction("Index", new {page});
		}
	}
}
