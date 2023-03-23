using System.Text;
using _66.WebApi_Cars.Middlewares;
using Entities.DataContext;
using Entities.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace _66.WebApi_Cars.Configuration;

internal static class ConfigureApp
{
	internal static void Configure(WebApplication app)
	{
		app.UseHttpsRedirection();

		using (var scope = app.Services.CreateScope())
		{
			var dbContext = scope.ServiceProvider.GetRequiredService<WebApiDbContext>();
			dbContext.Database.Migrate();

			var existingUserAdministrator = dbContext.Users.FirstOrDefault(x => x.RoleId == 1);
			if (existingUserAdministrator == null)
			{
				dbContext.Users.Add(new User
				{
					Nombre = "admin",
					Password = "1234Aa",
					RoleId = 1,
					Email = "admin@myapp.com"
				});

				dbContext.SaveChanges();
			}
		}

		app.UseMiddleware(typeof(ExceptionHandlingMiddleware));

		app.UseAuthentication();
		app.UseAuthorization();

		app.MapControllers();
	}
}