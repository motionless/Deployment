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
			mapper.CreateMap<IProduct, ProductViewModel>();
			mapper.CreateMap<IEnvironment, EnvironmentViewModel>();
			mapper.CreateMap<IPackage,PackageViewModel>();
			mapper.CreateMap<IServer,ServerViewModel>();
			mapper.CreateMap<IWebsite,WebsiteViewModel>();
			mapper.CreateMap<IApplicationPool,ApplicationPoolViewModel>();
			mapper.CreateMap<IBinding,BindingViewModel>();
			mapper.CreateMap<IVirtualDirectory,VirtualDirectoryViewModel>();
			mapper.CreateMap<ISetupStep,SetupStepViewModel>();
		}
	}
}