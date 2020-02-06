using flows.Data;
using flows.Data.Factories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace flows
{
    public class DesignTimeContextFactory : IDesignTimeDbContextFactory<FlowsDbContext>
    {
		public FlowsDbContext CreateDbContext(string[] args)
		{
			var builder = new ConfigurationBuilder()
					  .SetBasePath(Directory.GetCurrentDirectory())
				  .AddJsonFile("appsettings.json");

			var config = builder.Build();
			var connectionString = config.GetConnectionString("Database");
			var optionsBuilder = new DbContextOptionsBuilder<FlowsDbContext>();
			optionsBuilder.UseSqlServer(connectionString);

			return new FlowsDbContext(optionsBuilder.Options);
		}
	}
}
