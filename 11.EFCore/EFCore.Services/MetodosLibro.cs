using EF.Core.Entidades.Libros;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Services
{
	public class MetodosLibro : IMetodosLibro
	{
		public int ActualizarLibro(DatabaseContext context, int id, string titulo)
		{
			var libro = DameLibro(context, id);
			libro.Titulo = titulo;

			context.Libros.Update(libro);

			return context.SaveChanges();
		}

		public int BorrarLibro(DatabaseContext context, string titulo)
		{
			var libro = DameLibro(context, titulo);
			context.Remove(libro);
			var changes = context.SaveChanges();

			Console.WriteLine("  ...Datos borrados...");

			return changes;
		}

		public Libro DameLibro(DatabaseContext context, int id)
		{
			return context.Libros.Where(x => x.Id == id).FirstOrDefault();
		}

		public Libro DameLibro(DatabaseContext context, string titulo)
		{
			return context.Libros.Where(x => x.Titulo == titulo).FirstOrDefault();
		}

		public List<Libro> DameTodosLosLibros(DatabaseContext context)
		{
			return context.Libros.ToList();
		}

		public List<Libro> DameTodosLosLibros(DatabaseContext context, string tematica)
		{
			return context.Libros.Where(x => x.Tematica == tematica).ToList();
		}

		public int InsertarLibros(DatabaseContext context, List<Libro> libros)
		{
			context.AddRange(libros);
			context.SaveChanges();

			return libros.Count;
		}

		public void LimpiaDatosLibros(DatabaseContext context)
		{
			context.Database.ExecuteSqlRaw("Truncate Table Libros");


			Console.WriteLine("  ...Datos borrados Libros...");
		}
	}
}
