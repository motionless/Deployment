using System;
using System.Collections.Generic;
using System.Linq;
using Motionless.Deployment.Data.Model;

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
		public bool CreateOrUpdateWebsite(Data.Model.Website website)
		{

			return false;
		}

		/// <summary>
		/// Creates the or update application pool.
		/// </summary>
		/// <param name="applicationPool">The application pool.</param>
		/// <returns></returns>
		public bool CreateOrUpdateApplicationPool(ApplicationPool applicationPool)
		{
			return false;
		}

		/// <summary>
		/// Creates the or update virtual directory.
		/// </summary>
		/// <param name="virtualDirectory">The virtual directory.</param>
		/// <returns></returns>
		public bool CreateOrUpdateVirtualDirectory(Data.Model.VirtualDirectory virtualDirectory)
		{
			return false;
		}

		/// <summary>
		/// Creates the or update bindings.
		/// </summary>
		/// <param name="bindings">The bindings.</param>
		/// <returns></returns>
		public bool CreateOrUpdateBindings(IEnumerable<Data.Model.Binding> bindings)
		{
			return false;
		}
	}
}

