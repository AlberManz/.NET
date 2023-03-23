using EF.Core.Entidades.Autores;
using EF.Core.Entidades.Libros;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Services
{
	public class DatabaseContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=003-0113\\SQLEXPRESS;Initial Catalog=EjercicioEFCore2;Integrated Security=True");
		}

		public DbSet<Autor> Autores { get; set; }
		public DbSet<Libro> Libros { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Autor>()
				.HasMany(x => x.Libros);

			modelBuilder.Entity<Libro>()
				.HasOne(x => x.Autor);
		}
	}
}
