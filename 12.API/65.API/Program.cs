using DataAccess.Generic;
using Entities.DataContext;
using Entities.DataContext.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using DataAccess.Repositories;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); // Se meterá en la carpeta Controllers para ejecutar las llamadas que estarán ahí
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); // Usamos un servicio en el que me busca todos los endpoints que usa la app (Get, Put, Post...)
builder.Services.AddSwaggerGen(); // Este te pinta el HTML


// Justo antes de que se construya la app podemos configurar la app


// Le decimos a qué base de datos nos vamos a conectar (en este caso Patterns_DB
builder.Services.AddDbContext<WebApiDbContext>(options => options.UseInMemoryDatabase(databaseName: "Patterns_DB"));
// Cada vez que creemos una interfaz nueva necesitamos la siguiente línea
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); // Cuando alguien pida un IUnitOfWork tendrá que hacer referencia a UnitOfWork
// Añadir a los servicios que tiene la Api al arrancar el interfaz genérico
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>)); // Cuando quieres hacer que te resuelva para una interfaz que es genérica, que nos pueden pasar cualquier cosa, la nomenclatura es con el typeof tal cual como está
// Llamamos a los métodos de la interfaz y luego se inyectan en las clases que la utilicen. Se llaman aquí en un único sitio y si tienes que cambiarla solo se hace desde aquí. Es más, puedes ir preparando una clase durante "x" tiempo y cuando ya ves que funciona la metes directamente ahí sustituyendo a la anterior (en el ejemplo es estar usando BD SQL y cambiar a MySQL, aunque solo se vea con un cw)
builder.Services.AddScoped<IAlbumesRepository, AlbumesRepository>();


// Esto lo añadimos para poder documentar la API con los comentarios con /// y que aparezca en Swagger cuando lanzamos el programa
// Además en el proyecto (65.API) hemos dado doble click y añadido <GenerateDocumentationFile>true</GenerateDocumentationFile>

builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo
  {
    Title = "API Albumes y Artistas",
    Version = "v1",
    Description = "Mantenimiento de Albumes y Artistas."
  });
  // Set the comments path for the Swagger JSON and UI.    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
  var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
  var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
  c.IncludeXmlComments(xmlPath);
});


var app = builder.Build();


// Una vez que la app está cargada la aplicación tenemos que crear un ámbito (scope) con unos servicios para que llame a la base de datos(WebApiDbContext)
using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;
  var dbContext = services.GetRequiredService<WebApiDbContext>();

  DBInitializer.Initialize(services);
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // Si estamos en modo desarrollo usa swagger y se vea como lo muestra swagger
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Se configura para que se use https para encriptar las llamadas (esto viene ya configurado)

app.UseAuthorization(); // Por defecta utiliza Authorization

app.MapControllers(); // Nos mapea los Controllers que tenemos configurados

app.Run(); // Esto lanza la app
