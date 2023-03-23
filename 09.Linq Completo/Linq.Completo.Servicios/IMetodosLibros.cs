using Linq.Completo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.Completo.Servicios
{
	public interface IMetodosLibros
	{
		List<Book> GetTopLibrosVentas(bool esMayorNumeroVentas, int topLibros);
		List<Book> GetLibrosPublicadosUltimosAnios(int anio);
		Book GetLibroMasViejo();
	}
}
