﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
		public Iesi.Collections.Generic.ISet<IServerRole> ServerRoles { get; set; }
		public Iesi.Collections.Generic.ISet<IEnvironment> Environments { get; set; }
	}
}