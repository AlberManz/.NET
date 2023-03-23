using Linq.Completo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Linq.Completo.Servicios
{
  public class MetodosAutores : IMetodosAutores
  {
    List<Author> autores = Author.Authors();
    List<Book> libros = Book.Books();


    public List<AuthorExtendido> GetAutoresConCantidadLibrosPublicados()
    {
      throw new NotImplementedException();
    }


    public List<AuthorExtendido> GetAutoresConLibroQueComiencePor(string comiencePor)
    {
      return (from autor in autores
              join libro in libros on autor.AuthorId equals libro.AuthorId
              where libro.Title.ToLower().StartsWith(comiencePor.ToLower())
              select new AuthorExtendido(autor.AuthorId, autor.Name, libro.Title)).ToList();
    }

    public AuthorExtendido GetAutorMayorNumeroLibrosPublicados()
    {
      var queryAuthor = (from autor in autores
                         join libro in libros on autor.AuthorId equals libro.AuthorId
                         group libro by libro.AuthorId
          into groupedLibros // Agrupamos por libro libro.AuthorId y lo metemos en una variable groupedLibros para guardarlo en una variable y no tener que hacer los dos bucles foreach
                             // El group by devuelve un objeto de elementos agrupados por una key
                             // ESTO SE HACE EN LUGAR DE LOS DOS FOREACH
                         select new // Montamos un objeto en el que guardamos el id del autore y cuántos libros tiene ese autor
                         {
                           AuthorId = groupedLibros.Key, // guardar el AuthorId que lo sacamos de groupedLibros.Key(las hemos guardado al hacer el group)
                           Counted = groupedLibros.Count() // guardar cuántos libros por cada autor tenemos que lo guardamos dentro de la variable Counted
                         }) //
        .OrderByDescending(x => x.Counted) // Ordenamos descendente por cuántos libros tiene
        .First(); // Solo cogemos el primero que será el que más libros tiene
      // En este momento tenemos una variable con el AuthorId y el número de libros ordenados descendentes y donde solo cogeré el primero
      // Como quiero devolver el AuthorExtendido y ya tenemos guardado el id y el número de libros en la variable, tenemos que acceder al nombre
      return autores
        .Where(x => x.AuthorId == queryAuthor.AuthorId)
        .Select(x => new AuthorExtendido(x.AuthorId, x.Name, queryAuthor.Counted))
        .First();
      // Retornamos autores donde el id del autor será igual al id que sacamos del query
      // Seleccionamos un autor donde creamos un nuevo autor extendido con el autor id del autor, el nombre del autor y sacamos la cantidad de libro
      // de la query
      // Cogemos el primero
    }
  }
}
