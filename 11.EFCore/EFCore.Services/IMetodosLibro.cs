using EF.Core.Entidades.Libros;

namespace EFCore.Services
{
	public interface IMetodosLibro
	{
		void LimpiaDatosLibros(DatabaseContext context);
		int InsertarLibros(DatabaseContext context, List<Libro> libros);
		int BorrarLibro(DatabaseContext context, string titulo);
		int ActualizarLibro(DatabaseContext context, int id, string titulo);
		List<Libro> DameTodosLosLibros(DatabaseContext context);
		Libro DameLibro(DatabaseContext context, int id);
		Libro DameLibro(DatabaseContext context, string titulo);

		List<Libro> DameTodosLosLibros(DatabaseContext context, string tematica);
	}
}
