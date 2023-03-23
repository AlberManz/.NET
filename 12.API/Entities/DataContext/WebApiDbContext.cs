using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace Entities.DataContext
{
  public class WebApiDbContext : DbContext // Tenemos que ponerle que hereda de DbContext
  {
    public DbSet<Album> Albumes { get; set; }
    public DbSet<Artista> Artistas { get; set; }

    public WebApiDbContext(DbContextOptions<WebApiDbContext> options) // Para que alguien desde fuera me pase unas opciones de configuración y nosotros podamos responder
      : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // Si no me llaman con datos de configuración usar esta por defecto
    {
      base.OnConfiguring(optionsBuilder);

      optionsBuilder.UseInMemoryDatabase("Patterns_DB");
    }
  }
}
