using Linq.Completo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.Completo.Servicios
{
	public interface IMetodosAutores
	{
		AuthorExtendido GetAutorMayorNumeroLibrosPublicados();
		List<AuthorExtendido> GetAutoresConCantidadLibrosPublicados();
		List<AuthorExtendido> GetAutoresConLibroQueComiencePor(string comiencePor);
	}
}
