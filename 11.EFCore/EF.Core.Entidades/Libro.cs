using EF.Core.Entidades.Autores;

namespace EF.Core.Entidades.Libros
{
	public class Libro
	{
		public int Id { get; set; }
		public string Titulo { get; set; }
		public int AnioPublicacion { get; set; }
		public int Ventas { get; set; }
		public string Tematica { get; set; }
		public Autor Autor { get; set; }
	}
}
