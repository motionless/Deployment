﻿using System.ComponentModel.Composition;
using Motionless.Data.Persistence;
using Motionless.Deployment.Contracts.Data.Model;
using Motionless.Deployment.Contracts.Services;
using Motionless.Deployment.Data.Model;

namespace Motionless.Deployment.Services
{
	[Export(typeof(IPackageConfigurationService))]
	public class PackageConfigurationService : BaseService<PackageConfiguration, IPackageConfiguration>, IPackageConfigurationService
	{
		
	}
}
