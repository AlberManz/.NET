using Entities.DataContext;
using Microsoft.EntityFrameworkCore;

namespace _66.WebApi_Cars.Configuration;

internal static class ConfigureDbContext
{
	internal static void AddDbContext(ConfigurationManager configuration, IServiceCollection services)
	{
		services.AddDbContext<WebApiDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("connectionString")));
	}
}