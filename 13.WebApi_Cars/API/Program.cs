using _66.WebApi_Cars.Configuration;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();

ConfigureSwagger.AddSwagger(builder.Configuration, builder.Services);
ConfigureDbContext.AddDbContext(builder.Configuration, builder.Services);
ConfigureAuthentication.AddAuthentication(builder.Configuration, builder.Services);
ConfigureCustomServices.AddCustomServices(builder.Configuration, builder.Services);
ConfigureLogger.AddLogger(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

ConfigureApp.Configure(app);

app.Run();
