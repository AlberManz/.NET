using System.Text;
using DataAccess.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;

namespace _66.WebApi_Cars.Configuration;

internal static class ConfigureLogger
{
	internal static void AddLogger(WebApplicationBuilder builder)
	{
		var logger = new LoggerConfiguration()
			.ReadFrom.Configuration(builder.Configuration)
			.Enrich.FromLogContext()
			.CreateLogger();

		builder.Logging.ClearProviders();
		builder.Logging.AddSerilog(logger);
	}
}