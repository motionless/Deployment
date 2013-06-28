using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Motionless.Deployment.Admin.Extensions;
using Motionless.Deployment.Contracts.Data.Model;

namespace Motionless.Deployment.Admin.Models
{
	public class ServerViewModel : IServer
	{
		public long Id { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public string Name { get; set; }
		public ISet<IServerRole> ServerRoles { get; set; }
		
		public ISet<IEnvironment> Environments { get; set; }

		public List<long> SelectedEnvironmentIds { get; set; }

		
		public List<IEnvironment> SelectableEnvironments { get; set; }
		public MultiSelectList EnvironmentsSelectList
		{
			get
			{
				var listItems = SelectableEnvironments.Select(p => new SelectListItem() { Text = p.DisplayName(), Value = p.Id.ToString() }).ToList();

				return new MultiSelectList(listItems,
										"Value",
										"Text",
										Environments != null ? Environments.Select(env => env.Id) : null);
			}
		}

	}
}