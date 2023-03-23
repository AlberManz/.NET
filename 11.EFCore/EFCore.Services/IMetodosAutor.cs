using EF.Core.Entidades.Autores;
using EF.Core.Entidades.AutorExtendido;

namespace EFCore.Services
{
	public interface IMetodosAutor
	{
		void LimpiaDatosAutores(DatabaseContext context);
		int InsertaAutor(DatabaseContext context, Autor autor);
		List<AutorExtendido> ObtenerAutoresConLibrosPublicados(DatabaseContext context, string nombreAutor);
		int BorrarAutor(DatabaseContext context, string nombreAutor);
		List<Autor> DameTodosAutores(DatabaseContext context);
		Autor DameAutor(DatabaseContext context, int id);
		Autor DameAutor(DatabaseContext context, string nombreAutor);
	}
}
