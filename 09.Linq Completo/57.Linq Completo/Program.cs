// See https://aka.ms/new-console-template for more information

using Linq.Completo.Entidades;
using Linq.Completo.Servicios;

IMetodosAutores metodosAutores = new MetodosAutores();
IMetodosLibros metodosLibros = new MetodosLibros();

Separador();
var topNumeroVentas = 3;
bool esSentidoDescendente = false;
var sentido = esSentidoDescendente ? "ascendente" : "descendente";

Separador();
var librosConMasVentas = metodosLibros.GetTopLibrosVentas(esSentidoDescendente, topNumeroVentas);
Console.WriteLine($"Mostrado el top {topNumeroVentas} en sentido {sentido}");
MostrarDatosLibros(librosConMasVentas);

Separador();
esSentidoDescendente = true;
sentido = esSentidoDescendente ? "ascendente" : "descendente";
var librosConMenosVentas = metodosLibros.GetTopLibrosVentas(esSentidoDescendente, topNumeroVentas);
Console.WriteLine($"Mostrando el top {topNumeroVentas} en sentido {sentido}");
MostrarDatosLibros(librosConMenosVentas);

Separador();
var autorMasLibrosPublicados = metodosAutores.GetAutorMayorNumeroLibrosPublicados();
Console.WriteLine("Mostrando el autor con más libros publicados");
MostrarDatosAutores(new List<AuthorExtendido> { autorMasLibrosPublicados });

Separador();
var listadoAutoresConCantidadLibrosPublicados = metodosAutores.GetAutoresConCantidadLibrosPublicados();
Console.WriteLine("Mostrando los autores con la cantidad de libros publicados");
MostrarDatosAutores(listadoAutoresConCantidadLibrosPublicados);

Separador();
var librosPublicadosNumeroUltimosAnios = 50;
var listadoLibrosPublicadosUltimosAnios = metodosLibros.GetLibrosPublicadosUltimosAnios(librosPublicadosNumeroUltimosAnios);
Console.WriteLine($"Mostrando los libros publicados en los últimos {librosPublicadosNumeroUltimosAnios} años");
MostrarDatosLibros(listadoLibrosPublicadosUltimosAnios);

Separador();
var libroMasViejo = metodosLibros.GetLibroMasViejo();
Console.WriteLine("Mostrando el libro más viejo");
MostrarDatosLibros(new List<Book> { libroMasViejo });

Separador();
var comiencePor = "El";
var listadoAutoresConLibroComiencePor = metodosAutores.GetAutoresConLibroQueComiencePor(comiencePor);
Console.WriteLine($"Mostrando autores con libros que comiencen por {comiencePor}");
MostrarDatosAutores(listadoAutoresConLibroComiencePor);

void MostrarDatosLibros(List<Book> libros)
{
  foreach (var libro in libros)
  {
    Console.WriteLine($"Título: {libro.Title} " +
      $"Autor: {libro.AuthorId} " +
      $"Año publicación: {libro.PublicationDate} " +
      $"Ventas: {libro.Sales}");
  }

  Console.WriteLine();
}

void MostrarDatosAutores(List<AuthorExtendido> listadoAutores)
{
  foreach (var autor in listadoAutores)
  {
    string mensaje = $"Id: {autor.AuthorId} " +
      $"Nombre: {autor.Name} " +
      $"NumeroLibrosPublicados: {autor.NumeroLibrosPublicado} ";

    if (!string.IsNullOrEmpty(autor.TituloLibro))
    {
      mensaje += $"TituloLibro: {autor.TituloLibro}";
    }

    Console.WriteLine(mensaje);
  }

  Console.WriteLine();
}

void Separador()
{
  Console.ForegroundColor = ConsoleColor.DarkMagenta;
  Console.WriteLine("---------------------------------------------------------------------------");
  Console.ResetColor();
  Console.WriteLine();
}
