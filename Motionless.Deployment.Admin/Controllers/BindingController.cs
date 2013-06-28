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
	public class BindingController : BaseController
	{
		public ActionResult Index(int? page)
		{
			var viewModel = new BindingListViewModel();
			var pageNumber = (page ?? 1) - 1;
			long totalCount;

			IEnumerable<IBinding> bindings = BindingService.GetAll(pageNumber, PageSize, out totalCount);
			viewModel.Bindings = new StaticPagedList<IBinding>(bindings, pageNumber + 1, PageSize, (int)totalCount);

			return View(viewModel);
		}

		public ActionResult Details(int id)
		{
			return View();
		}

		public ActionResult Create()
		{
			var viewModel = new BindingViewModel();

			viewModel.Websites = WebsiteService.GetAll().ToList();
			viewModel.SelectableServers = ServerService.GetAll().ToList();
			viewModel.SelectableEnvironments = EnvironmentService.GetAll().ToList();

			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Create(BindingViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var binding = AutoMapper.Mapper.Map<BindingViewModel, IBinding>(viewModel);
				PopulateSelectListsToModel(viewModel, binding);
				BindingService.CreateOrUpdate(binding);
				return RedirectToAction("Index");
			}
			return View(viewModel);
		}

		public ActionResult Edit(long? id, int? page)
		{
			if (id.HasValue)
			{
				var viewModel = AutoMapper.Mapper.Map<IBinding, BindingViewModel>(BindingService.GetById(id.Value));
				viewModel.Websites = WebsiteService.GetAll().ToList();
				viewModel.SelectableServers = ServerService.GetAll().ToList();
				viewModel.SelectableEnvironments = EnvironmentService.GetAll().ToList();
				return View(viewModel);
			}
			return RedirectToAction("Create");
		}

		[HttpPost]
		public ActionResult Edit(BindingViewModel viewModel, int? page)
		{
			if (ModelState.IsValid)
			{
				var binding = AutoMapper.Mapper.Map<BindingViewModel, IBinding>(viewModel);
				PopulateSelectListsToModel(viewModel, binding);
				BindingService.CreateOrUpdate(binding);
				return RedirectToAction("Index", new {page});
			}
			return View(viewModel);
		}

		private void PopulateSelectListsToModel(BindingViewModel viewModel, IBinding binding)
		{
			if (viewModel != null)
			{
				if (viewModel.SelectedWebsiteId > 0)
				{
					binding.Website = WebsiteService.GetById(viewModel.SelectedWebsiteId);
				}

				if (viewModel.SelectedServerIds.Any())
				{
					if (binding.Servers == null)
					{
						binding.Servers = new HashSet<IServer>();
					}
					foreach (long selectedServerId in viewModel.SelectedServerIds)
					{
						binding.Servers.Add(ServerService.GetById(selectedServerId));
					}
				}
				if (viewModel.SelectedEnvironmentIds.Any())
				{
					if (binding.Environments == null)
					{
						binding.Environments = new HashSet<IEnvironment>();
					}
					foreach (long selectedEnvironmentId in viewModel.SelectedEnvironmentIds)
					{
						binding.Environments.Add(EnvironmentService.GetById(selectedEnvironmentId));
					}
				}
			}
		}

		public ActionResult Delete(int id, int? page)
		{
			var binding = BindingService.GetById(id);
			if (binding != null)
			{
				BindingService.Delete(binding);
			}

			return RedirectToAction("Index", new { page });
		}
	}
}
