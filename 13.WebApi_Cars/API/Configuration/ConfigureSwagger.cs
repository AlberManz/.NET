using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace _66.WebApi_Cars.Configuration;

internal static class ConfigureSwagger
{
	internal static void AddSwagger(ConfigurationManager configuration, IServiceCollection services)
	{
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		services.AddEndpointsApiExplorer();
		services.AddSwaggerGen(cfg =>
		{
			cfg.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
			{
				Type = SecuritySchemeType.Http,
				BearerFormat = "JWT",
				In = ParameterLocation.Header,
				Scheme = "bearer",
				Description = "Please insert JWT token into field"
			});

			cfg.AddSecurityRequirement(new OpenApiSecurityRequirement
			{
				{
					new OpenApiSecurityScheme
					{
						Reference = new OpenApiReference
						{
							Type = ReferenceType.SecurityScheme,
							Id = "Bearer"
						}
					},
					new List<string>()
				}
			});
		});
	}
}