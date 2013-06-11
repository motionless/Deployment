using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

		
		public ISet<IEnvironment> SelectableEnvironments { get; set; }
		public MultiSelectList EnvironmentsSelectList
		{
			get
			{
				var listItems = SelectableEnvironments.Select(p => new SelectListItem() { Text = p.Name, Value = p.Id.ToString() }).ToList();

				return new SelectList(listItems,
										"Value",
										"Text",
										/*Product != null ? Product.Id : 0*/0);
			}
		}

	}
}