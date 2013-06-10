using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bootstrap.AutoMapper;
using Motionless.Deployment.Contracts.Data.Model;
using Motionless.Deployment.Data.Model;

namespace Motionless.Deployment.Services
{
	public class AutoMapCreator : IMapCreator
	{
		public void CreateMap(IProfileExpression mapper)
		{
			mapper.CreateMap<IProduct, Product>();
			mapper.CreateMap<IEnvironment, Data.Model.Environment>();
			mapper.CreateMap<IServer, Server>();
			mapper.CreateMap<IPackage, Package>();
			mapper.CreateMap<IApplicationPool, ApplicationPool>();
			mapper.CreateMap<IBinding, Binding>();
			mapper.CreateMap<IConfiguration, Configuration>();
			mapper.CreateMap<ISetupStep, SetupStep>();
			mapper.CreateMap<IVirtualDirectory, VirtualDirectory>();
			mapper.CreateMap<IPackageConfiguration, PackageConfiguration>();
		}
	}
}
