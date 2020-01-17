using flows.Data;
using flows.Data.Factories;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace flows
{
    public class DesignTimeContextFactory : IDesignTimeDbContextFactory<FlowDbContext>
    {
		public FlowDbContext CreateDbContext(string[] args)
		{
			var builder = new ConfigurationBuilder()
					  .SetBasePath(Directory.GetCurrentDirectory())
				  .AddJsonFile("appsettings.json");

			var config = builder.Build();
			var connectionString = config.GetConnectionString("Database");
			var repositoryFactory = new FlowDbContextFactory();

			return repositoryFactory.CreateDbContext(connectionString);
		}
	}
}
