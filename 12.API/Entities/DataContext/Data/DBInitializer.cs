using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Entities.DataContext.Data
{
  public static class DBInitializer // Esta clase la hemos creado para cargar(inicializar) los datos
  {
    public static void Initialize(IServiceProvider serviceProvider)
    {
      // En Program.cs ya ha añadido el contexto y las opciones sobre la base de datos que vamos a trabajar y aquí creamos un
      // context que sea una nueva WebApiDbContext en la que le pasamos unas optiones que ya hemos configurado en Program.cs
      // en vez de escribirlo otra vez, el serviceProvider nos permite acceder a esos datos con el GetRequiredService
      // que tiene un DbContextOptions (que nos lo habilita añadir EntityFrameworCore y Extensions.DependencyInjection)
      // y le decimos de qué tipo (WebApiDbContext)
      using (var context = new WebApiDbContext(serviceProvider.GetRequiredService<DbContextOptions<WebApiDbContext>>()))
      {
        // En este punto ya tenemos un context al que le iremos añadiendo los datos a mano
        context.Artistas.AddRange(
          new Artista()
          {
            Nombre = "Luis Miguel",
            Edad = 58,
            País = "España"
          },
          new Artista()
          {
            Nombre = "Ricardo Arjona",
            Edad = 45,
            País = "España"
          },
          new Artista()
          {
            Nombre = "Kalimba",
            Edad = 22,
            País = "Chile"
          });

        context.SaveChanges();

        context.Albumes.AddRange(
          new Album()
          {
            ArtistaId = context.Artistas.Where(x => x.Nombre == "Kalimba").FirstOrDefault().Id,
            Titulo = "Mi Otro Yo",
            Precio = 200,
            Anio = 2008
          },
          new Album()
          {
            ArtistaId = context.Artistas.Where(x => x.Nombre == "Kalimba").FirstOrDefault().Id,
            Titulo = "Aerosoul",
            Precio = 275,
            Anio = 2004
          },
          new Album()
          {
            ArtistaId = context.Artistas.Where(x => x.Nombre == "Ricardo Arjona").FirstOrDefault().Id,
            Titulo = "Circo Soledad",
            Precio = 150,
            Anio = 2007
          },
          new Album()
          {
            ArtistaId = context.Artistas.Where(x => x.Nombre == "Luis Miguel").FirstOrDefault().Id,
            Titulo = "Romance",
            Precio = 300,
            Anio = 1991
          });

        context.SaveChanges();
      }
    }
  }
}
