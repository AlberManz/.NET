using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace _66.WebApi_Cars.Configuration;

internal static class ConfigureAuthentication
{
	internal static void AddAuthentication(ConfigurationManager configuration, IServiceCollection services)
	{
		//Adding authentication
		services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			//Adding Jwt Bearer
			.AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JWT:Secret"])),
					ValidAudience = configuration["JWT:ValidAudience"],
					ValidIssuer = configuration["JWT:ValidIssuer"],
					ValidateIssuer = true,
					ValidateAudience = true
				};
			});
	}
}