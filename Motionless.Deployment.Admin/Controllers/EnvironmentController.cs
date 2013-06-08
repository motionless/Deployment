using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Motionless.Data.Persistence;
using Motionless.Deployment.Admin.Models;
using Motionless.Deployment.Contracts.Data.Model;
using PagedList;

namespace Motionless.Deployment.Admin.Controllers
{
	public class EnvironmentController : BaseController
	{
		public ActionResult Index(int? page)
		{
			var viewModel = new EnvironmentListViewModel();
			var pageNumber = (page ?? 1) - 1;
			long totalCount;
			
			IEnumerable<IEnvironment> environments = EnvironmentService.GetAll(pageNumber, PageSize, out totalCount);
			viewModel.Environments = new StaticPagedList<IEnvironment>(environments, pageNumber + 1, PageSize, (int)totalCount);

			return View(viewModel);
		}

		public ActionResult Details(int id)
		{
			return View();
		}

		public ActionResult Create()
		{
			var viewModel = new EnvironmentViewModel();

			viewModel.Products = ProductService.GetAll().ToList();

			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Create(EnvironmentViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var environment = AutoMapper.Mapper.Map<EnvironmentViewModel, IEnvironment>(viewModel);
				if (viewModel != null && viewModel.SelectedProductId > 0)
				{
					environment.Product = ProductService.GetById(viewModel.SelectedProductId);
				}
				EnvironmentService.CreateOrUpdate(environment);
				return RedirectToAction("Index");
			}
			return View(viewModel);
		}

		public ActionResult Edit(long? id, int? page)
		{
			if (id.HasValue)
			{
				var viewModel = AutoMapper.Mapper.Map<IEnvironment, EnvironmentViewModel>(EnvironmentService.GetById(id.Value));
				viewModel.Products = ProductService.GetAll().ToList();
				viewModel.SelectedProductId = viewModel.Product.Id;

				return View(viewModel);
			}
			return RedirectToAction("Create");
		}

		[HttpPost]
		public ActionResult Edit(EnvironmentViewModel viewModel , int? page)
		{
			if (ModelState.IsValid)
			{
				var environment = AutoMapper.Mapper.Map<EnvironmentViewModel, IEnvironment>(viewModel);
				if (viewModel != null && viewModel.SelectedProductId > 0)
				{
					environment.Product = ProductService.GetById(viewModel.SelectedProductId);
				}
				EnvironmentService.CreateOrUpdate(environment);
				return RedirectToAction("Index", new {page});
			}
			return View(viewModel);
		}

		public ActionResult Delete(int id, int? page)
		{
			var environment = EnvironmentService.GetById(id);
			if (environment != null)
			{
				EnvironmentService.Delete(environment);
			}

			return RedirectToAction("Index", new { page });
		}
	}
}
