using System;
using System.Collections.Generic;
using Motionless.Data.Persistence;

namespace Motionless.Deployment.Contracts.Data.Model
{
	public interface IPackageConfiguration : IBaseObject
	{
		string Name { get; set; }
		Version Version { get; set; }
		bool IsActive { get; set; }
		ISet<IPackage> Packages { get; set; }
		IProduct Product { get; set; }
		string SearchPath { get; set; }
		string SearchPattern { get; set; }
	}
}