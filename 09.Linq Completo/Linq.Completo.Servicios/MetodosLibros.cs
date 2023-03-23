using Linq.Completo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.Completo.Servicios
{
  public class MetodosLibros : IMetodosLibros
  {
    List<Book> libros = Book.Books();


    public Book GetLibroMasViejo()
    {
      throw new NotImplementedException();
    }

    public List<Book> GetLibrosPublicadosUltimosAnios(int anio)
    {
      throw new NotImplementedException();
    }

    public List<Book> GetTopLibrosVentas(bool esMayorNumeroVentas, int topLibros)
    {
      var query = (from libro in libros
                   select libro);
      if (esMayorNumeroVentas) // Si esMayorNumeroVentas true devolver la query ordenada por ventas de forma ascendente (de caro a barato)
      {
        query = query.OrderBy(x => x.Sales);
      }
      else
      {
        query = query.OrderByDescending(x => x.Sales); // Si es false se ordena descendente (de barato a caro)
      }

      return query.Take(topLibros).ToList(); // retornar la query tomando los que se indiquen en el parámetro topLibros (en este caso el top 3)
    }
  }
}
