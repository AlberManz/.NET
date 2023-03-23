using EF.Core.Entidades.Libros;

namespace EF.Core.Entidades.Autores
{
	public class Autor
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public List<Libro> Libros { get; set; }
	}
}
