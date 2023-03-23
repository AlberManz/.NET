using EF.Core.Entidades.Autores;
using EF.Core.Entidades.AutorExtendido;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Services
{
	public class MetodosAutor : IMetodosAutor
	{
		public int BorrarAutor(DatabaseContext context, string nombreAutor)
		{
			var autor = DameAutor(context, nombreAutor);
			context.Remove(autor);

			var changes = context.SaveChanges();

			Console.WriteLine("... Datos Borrados ...");

			return changes;
		}

		public Autor DameAutor(DatabaseContext context, int id)
		{
			throw new NotImplementedException();
		}

		public Autor DameAutor(DatabaseContext context, string nombreAutor)
		{
			return context.Autores.Where(x => x.Nombre == nombreAutor).FirstOrDefault();
		}

		public List<Autor> DameTodosAutores(DatabaseContext context)
		{
			return context.Autores.ToList();
		}

		public int InsertaAutor(DatabaseContext context, Autor autor)
		{
			context.Add(autor);
			context.SaveChanges();

			return autor.Id;
		}

		public void LimpiaDatosAutores(DatabaseContext context)
		{
			context.Database.ExecuteSqlRaw("DELETE FROM Autores; DBCC CHECKIDENT('EjercicioEFCore2.dbo.Autores', RESEED, 0);");			

			Console.WriteLine("  ...Datos borrados Autores...");
		}

		public List<AutorExtendido> ObtenerAutoresConLibrosPublicados(DatabaseContext context, string nombreAutor)
		{
			//De esta forma se trae todos los datos de BD y después hace la consulta en LINQ en memoria (Poco eficiente)
			//var queryGrouped = (from autor in context.Autores.ToList()
			//					join libro in context.Libros.ToList() on autor.Id equals libro.Autor.Id
			//					where autor.Nombre == nombreAutor
			//					group libro by libro.Autor.Id into groupedLibros
			//					select groupedLibros);

			//var listAutores = new List<AutorExtendido>();

			//foreach (var groupedLibro in queryGrouped)
			//{
			//	var autor = context.Autores.Where(x => x.Id == groupedLibro.Key).First();

			//	listAutores.Add(new AutorExtendido { Id = autor.Id, Libros = autor.Libros, Nombre = autor.Nombre, NumeroLibros = groupedLibro.Count() });
			//}

			//return listAutores;

			//De esta forma la consulta entera se ejecuta en el servidor de base de datos (Más efeciente)
			return (from autor in context.Autores
					join libro in context.Libros on autor.Id equals libro.Autor.Id
					where autor.Nombre == nombreAutor
					group libro by new { libro.Autor.Id, autor.Nombre } into groupedLibros
					select new AutorExtendido
					{
						Id = groupedLibros.Key.Id,
						Nombre = groupedLibros.Key.Nombre,
						NumeroLibros = groupedLibros.Count()
					}).ToList();
		}
	}
}
