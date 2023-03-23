using System.Text;
using DataAccess.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace _66.WebApi_Cars.Configuration;

internal static class ConfigureCustomServices
{
	internal static void AddCustomServices(ConfigurationManager configuration, IServiceCollection services)
	{
		services.AddScoped<IUnitOfWork, UnitOfWork>();
		services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
	}
}