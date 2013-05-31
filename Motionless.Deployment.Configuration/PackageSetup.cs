using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Web.Administration;
using Motionless.Deployment.Data.Model;
using ApplicationPool = Motionless.Deployment.Data.Model.ApplicationPool;
using Binding = Motionless.Deployment.Data.Model.Binding;

namespace Motionless.Deployment.Configuration
{
	public class PackageSetup
	{

		/// <summary>
		/// Installs the new package.
		/// </summary>
		/// <param name="package">The package.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentNullException">package</exception>
		public bool InstallNewPackage(Package package)
		{
			if (package == null) throw new ArgumentNullException("package");

			if (package.Websites != null && package.Websites.Any() && package.Websites.Select(website => website.ApplicationPool).Any())
			{
				var applicationPools = package.Websites.Select(website => website.ApplicationPool);
				foreach (var applicationPool in applicationPools)
				{
					CreateOrUpdateApplicationPool(applicationPool);
				}
			}
			
			if (package.Websites != null && package.Websites.Any())
			{
				foreach (var website in package.Websites)
				{
					CreateOrUpdateWebsite(website);

					if (website.VirtualDirectories.Any())
					{
						foreach (var virtualDirectory in website.VirtualDirectories)
						{
							CreateOrUpdateVirtualDirectory(virtualDirectory);
						}
					}

					if (website.Bindings.Any())
					{
						CreateOrUpdateBindings(website.Bindings);
					}
				}
			}

			return false;
		}

		/// <summary>
		/// Creates the or update website.
		/// </summary>
		/// <param name="website">The website.</param>
		/// <returns></returns>
		private bool CreateOrUpdateWebsite(Data.Model.Website website)
		{
			using (var serverManager = new ServerManager())
			{
				var existingSite = serverManager.Sites.FirstOrDefault(site => site.Name == website.Name);
				if (existingSite == null)
				{
					serverManager.Sites.Add(website.Name, website.PhysicalPath,0);
				}
				serverManager.CommitChanges();
				return true;
			}
		}

		/// <summary>
		/// Creates the or update application pool.
		/// </summary>
		/// <param name="applicationPool">The application pool.</param>
		/// <returns></returns>
		private void CreateOrUpdateApplicationPool(ApplicationPool applicationPool)
		{
			using (var serverManager = new ServerManager())
			{
				var existingPool = serverManager.ApplicationPools.FirstOrDefault(pool => pool.Name == applicationPool.Name) ??
				                   serverManager.ApplicationPools.Add(applicationPool.Name);

				existingPool.ManagedRuntimeVersion = applicationPool.ManagedRuntimeVersion;
				existingPool.AutoStart = true;
				existingPool.Enable32BitAppOnWin64 = applicationPool.Enable32BitAppOnWin64;
				existingPool.ProcessModel.IdleTimeout = new TimeSpan(0, 0, applicationPool.IdleTimeout);

				serverManager.CommitChanges();
			}
		}

		/// <summary>
		/// Creates the or update virtual directory.
		/// </summary>
		/// <param name="virtualDirectory">The virtual directory.</param>
		/// <returns></returns>
		public void CreateOrUpdateVirtualDirectory(Data.Model.VirtualDirectory virtualDirectory)
		{
			
		}

		/// <summary>
		/// Creates the or update bindings.
		/// </summary>
		/// <param name="bindings">The bindings.</param>
		/// <returns></returns>
		public void CreateOrUpdateBindings(IEnumerable<Data.Model.Binding> bindings)
		{
			using (var serverManager = new ServerManager())
			{
				if (bindings != null)
				{
					Binding firstBinding = bindings.FirstOrDefault();
					var website = serverManager.Sites.FirstOrDefault(site => firstBinding != null && site.Name == firstBinding.Website.Name);
					if (website != null)
					{
						website.Bindings.Clear();

						foreach (var binding in bindings)
						{
							var newBinding = website.Bindings.Add(string.Format("{0}:{1}:{2}",
							                                                    string.IsNullOrWhiteSpace(binding.IPAddress)
								                                                    ? "*"
								                                                    : binding.IPAddress,
							                                                    binding.Port,
							                                                    binding.Hostname), binding.Protocol);
							if (!string.IsNullOrWhiteSpace(binding.SslThumbPrint))
							{
								newBinding.CertificateHash = System.Text.Encoding.ASCII.GetBytes(binding.SslThumbPrint);
							}
						}
					}
				}
				serverManager.CommitChanges();
			}
		}
	}
}

