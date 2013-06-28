using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Motionless.Deployment.Admin.Extensions;
using Motionless.Deployment.Contracts.Data.Model;

namespace Motionless.Deployment.Admin.Models
{
	public class BindingViewModel : IBinding
	{
		public long Id { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		
		public string Protocol { get; set; }
		public string IPAddress { get; set; }
		public int Port { get; set; }
		public string Hostname { get; set; }
		public string SslThumbPrint { get; set; }



		#region Servers drop down

		public ISet<IServer> Servers { get; set; }
		public List<IServer> SelectableServers { get; set; }
		public List<long> SelectedServerIds { get; set; }

		public MultiSelectList ServersSelectList
		{
			get
			{
				var items = SelectableServers.Select(p => new SelectListItem() {Text = p.Name, Value = p.Id.ToString()}).ToList();

				SelectedServerIds = Servers != null ? Servers.Select(srv => srv.Id).ToList() : null;
				return new SelectList(items,
				                      "Value",
				                      "Text",
				                      SelectedServerIds);
			}
		}

		#endregion


		#region Environment drop down

		public ISet<IEnvironment> Environments { get; set; }
		public List<IEnvironment> SelectableEnvironments { get; set; }
		public List<long> SelectedEnvironmentIds { get; set; }

		public MultiSelectList EnvironmentsSelectList
		{
			get
			{
				var items = SelectableEnvironments.Select(p => new SelectListItem() {Text = p.DisplayName(), Value = p.Id.ToString()}).ToList();

				SelectedEnvironmentIds = Environments != null ? Environments.Select(env => env.Id).ToList() : null;
				return new SelectList(items,
				                      "Value",
				                      "Text",
				                      SelectedEnvironmentIds);
			}
		}

		#endregion


		#region Website drop down

		public IList<IWebsite> Websites { get; set; }
		public IWebsite Website { get; set; }
		public long SelectedWebsiteId { get; set; }

		public SelectList WebsitesSelectList
		{
			get
			{
				var items = Websites.Select(p => new SelectListItem() {Text = p.Name, Value = p.Id.ToString()}).ToList();
				items.Insert(0, new SelectListItem {Text = string.Format("<-{0}->", "No Website"), Value = "0"});

				SelectedWebsiteId = Website != null ? Website.Id : 0;
				return new SelectList(items,
				                      "Value",
				                      "Text",
				                      SelectedWebsiteId);
			}
		}

		#endregion


	}
}