using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Bootstrap.AutoMapper;
using Motionless.Deployment.Admin.Models;
using Motionless.Deployment.Contracts.Data.Model;

namespace Motionless.Deployment.Admin.Utilities
{
	public class AutoMapCreator : IMapCreator
	{
		public void CreateMap(IProfileExpression mapper)
		{
			mapper.CreateMap<IProduct, ProductViewModel>().MaxDepth(1);
			mapper.CreateMap<IEnvironment, EnvironmentViewModel>().MaxDepth(1);
			mapper.CreateMap<IPackage,PackageViewModel>().MaxDepth(1);
			mapper.CreateMap<IServer,ServerViewModel>().MaxDepth(1);
			mapper.CreateMap<IWebsite, WebsiteViewModel>().MaxDepth(1);
			mapper.CreateMap<IApplicationPool, ApplicationPoolViewModel>().MaxDepth(1);
			mapper.CreateMap<IBinding, BindingViewModel>().MaxDepth(1);
			mapper.CreateMap<IVirtualDirectory, VirtualDirectoryViewModel>().MaxDepth(1);
			mapper.CreateMap<ISetupStep, SetupStepViewModel>().MaxDepth(1);
			mapper.CreateMap<IPackageConfiguration, PackageConfigurationViewModel>().MaxDepth(1);
		}
	}
}