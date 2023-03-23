using EF.Core.Entidades.Autores;

namespace EF.Core.Entidades.AutorExtendido
{
	public class AutorExtendido : Autor
	{
		public int NumeroLibros { get; set; }
	}
}
