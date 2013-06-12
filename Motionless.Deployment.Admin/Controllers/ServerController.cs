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
	public class ServerController : BaseController
	{
		public ActionResult Index(int? page)
		{
			var viewModel = new ServerListViewModel();

			var pageNumber = (page ?? 1) - 1;
			long totalCount;
			IEnumerable<IServer> servers = ServerService.GetAll(pageNumber, PageSize, out totalCount);

			viewModel.Servers = new StaticPagedList<IServer>(servers, pageNumber + 1, PageSize, (int)totalCount);
			return View(viewModel);
		}

		public ActionResult Details(int id)
		{
			return View();
		}

		public ActionResult Create()
		{
			var viewModel = new ServerViewModel();
			viewModel.SelectableEnvironments = EnvironmentService.GetAll().ToList();
			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Create(ServerViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var server = AutoMapper.Mapper.Map<ServerViewModel, IServer>(viewModel);
				server.Environments = PopulateEnvironments(viewModel, server);
				ServerService.CreateOrUpdate(server);				
				return RedirectToAction("Index");
			}
			viewModel.SelectableEnvironments = EnvironmentService.GetAll().ToList();
			return View(viewModel);
		}

		public ActionResult Edit(int? id, int? page)
		{
			if (id.HasValue)
			{
				var viewModel = AutoMapper.Mapper.Map<IServer, ServerViewModel>(ServerService.GetById(id.Value));
				viewModel.SelectableEnvironments = EnvironmentService.GetAll().ToList();

				return View(viewModel);
			}
			return RedirectToAction("Create");
		}

		[HttpPost]
		public ActionResult Edit(ServerViewModel viewModel, int? page)
		{
			try
			{
				IServer server = AutoMapper.Mapper.Map<ServerViewModel, IServer>(viewModel);
				
				server.Environments = PopulateEnvironments(viewModel, server);

				ServerService.CreateOrUpdate(server);

				


				return RedirectToAction("Index",new {page});
			}
			catch
			{
				viewModel.SelectableEnvironments = EnvironmentService.GetAll().ToList();
				return View(viewModel);
			}
		}

		private HashSet<IEnvironment> PopulateEnvironments(ServerViewModel viewModel, IServer server)
		{
			var environments = new HashSet<IEnvironment>();
			foreach (long selectedEnvironmentId in viewModel.SelectedEnvironmentIds)
			{
				environments.Add(EnvironmentService.GetById(selectedEnvironmentId));
			}
			server.Environments = environments;
			return environments;
		}

		public ActionResult Delete(int id, int? page)
		{
			var server = ServerService.GetById(id);
			if (server != null)
			{
				ServerService.Delete(server);
			}

			return RedirectToAction("Index", new {page});
		}
	}
}
