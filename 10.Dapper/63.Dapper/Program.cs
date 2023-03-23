// See https://aka.ms/new-console-template for more information
using Dapper.Logica;
using Dapper.Servicios;
using System.Data.SqlClient;
using System.Data;
using Dapper.Entidades;

IMetodosAutor metodosAutor = new MetodosAutor();
IMetodosLibro metodosLibro = new MetodosLibro();

using IDbConnection connection = new SqlConnection("Data Source=LAPTOP-U82H7862\\SQLEXPRESS;Initial Catalog=EjercicioDapper;Integrated Security=True");

LimpiarDatosInicialesDB(connection);

InsertaDatosIniciales(connection);

MostrarDatosAutores(connection);

MostrarDatosLibros(connection);

MostrarDatosAutorLibrosPublicados(connection, "J. R. R. Tolkien");

BorrarAutor(connection, "Charles Dickens");

MostrarAutor(connection, "Charles Dickens");

BorrarLibro(connection, "Sueño en el pabellón rojo");

MostrarLibro(connection, "Sueño en el pabellón rojo");

var libro = metodosLibro.DameLibro(connection, "Don Quijote de la Mancha");

ActualizarLibro(connection, libro.Id, "Don Quijote de la Mancha Version 2");

MostrarLibro(connection, "Don Quijote de la Mancha Version 2");

connection.Close();

void LimpiarDatosInicialesDB(IDbConnection connection)
{
  metodosAutor.LimpiaDatosAutores(connection);
  metodosLibro.LimpiaDatosLibros(connection);
}

void InsertaDatosIniciales(IDbConnection connection)
{
  Console.WriteLine("Insertando datos iniciales...");

  var autor = new Autor { Nombre = "Miguel de Cervantes" };
  var idAutorInsertado = metodosAutor.InsertaAutor(connection, autor);
  var librosAutor = new List<Libro>
{
  new Libro{ Titulo = "Don Quijote de la Mancha", AnioPublicacion = 1605, Ventas = 500, IdAutor = idAutorInsertado }
};

  autor = new Autor { Nombre = "Charles Dickens" };
  idAutorInsertado = metodosAutor.InsertaAutor(connection, autor);
  librosAutor.Add(

  new Libro { Titulo = "Historia de dos ciudades", AnioPublicacion = 1859, Ventas = 200, IdAutor = idAutorInsertado }
);

  autor = new Autor { Nombre = "J. R. R. Tolkien" };
  idAutorInsertado = metodosAutor.InsertaAutor(connection, autor);
  librosAutor.AddRange(new List<Libro>
{
  new Libro{ Titulo = "El Señor de los Anillos", AnioPublicacion = 1978, Ventas = 150, IdAutor = idAutorInsertado },
  new Libro{ Titulo = "El hobbit", AnioPublicacion = 1982, Ventas = 100, IdAutor = idAutorInsertado },
});

  autor = new Autor { Nombre = "Antoine de Saint-Exupéry" };
  idAutorInsertado = metodosAutor.InsertaAutor(connection, autor);
  librosAutor.Add(
  new Libro { Titulo = "El principito", AnioPublicacion = 1951, Ventas = 140, IdAutor = idAutorInsertado });

  autor = new Autor { Nombre = "Cao Xueqin" };
  idAutorInsertado = metodosAutor.InsertaAutor(connection, autor);
  librosAutor.Add(
  new Libro { Titulo = "Sueño en el pabellón rojo", AnioPublicacion = 1792, Ventas = 100, IdAutor = idAutorInsertado }
  );

  autor = new Autor { Nombre = "Lewis Car" };
  idAutorInsertado = metodosAutor.InsertaAutor(connection, autor);
  librosAutor.Add(
  new Libro { Titulo = "Las aventuras de Alicia en el país de las maravillas", AnioPublicacion = 1865, Ventas = 100, IdAutor = idAutorInsertado });

  autor = new Autor { Nombre = "Agatha Christie" };
  idAutorInsertado = metodosAutor.InsertaAutor(connection, autor);
  librosAutor.Add(
  new Libro { Titulo = "Diez negritos", AnioPublicacion = 1939, Ventas = 100, IdAutor = idAutorInsertado });

  autor = new Autor { Nombre = "C. S. Lewis" };
  idAutorInsertado = metodosAutor.InsertaAutor(connection, autor);
  librosAutor.Add(
  new Libro { Titulo = "El león, la bruja y el armario", AnioPublicacion = 1950, Ventas = 85, IdAutor = idAutorInsertado });

  autor = new Autor { Nombre = "Dan Brown" };
  idAutorInsertado = metodosAutor.InsertaAutor(connection, autor);
  librosAutor.Add(
  new Libro { Titulo = "El código Da Vinci", AnioPublicacion = 2003, Ventas = 80, IdAutor = idAutorInsertado });

  autor = new Autor { Nombre = "J. D. Salinger" };
  idAutorInsertado = metodosAutor.InsertaAutor(connection, autor);
  librosAutor.Add(
  new Libro { Titulo = "El guardián entre el centeno", AnioPublicacion = 1951, Ventas = 65, IdAutor = idAutorInsertado });

  metodosLibro.InsertarLibros(connection, librosAutor);

  Console.WriteLine("Datos iniciales insertados...");

}

void MostrarDatosAutores(IDbConnection connection)
{
  Console.WriteLine("Mostrando datos de Autores en BD");

  var autores = metodosAutor.DameTodosAutores(connection);
  autores.ForEach(z => Console.WriteLine("Id: {0} - Nombre: {1} ", z.Id, z.Nombre));

}

void MostrarDatosLibros(IDbConnection connection)
{
  Console.WriteLine("Mostrando datos de Libros en BD");

  var libros = metodosLibro.DameTodosLosLibros(connection);
  libros.ForEach(z => Console.WriteLine("Id: {0} - Titulo: {1} AñoPublicación: {2} Ventas: {3} IdAutor: {4}", z.Id, z.Titulo, z.AnioPublicacion, z.Ventas, z.IdAutor));
}

void MostrarDatosAutorLibrosPublicados(IDbConnection connection, string nombreAutor)
{
  var autoresConLibrosPublicados = metodosAutor.ObtenerAutoresConLibrosPublicados(connection, nombreAutor);

  Console.WriteLine("Autores con Libros Publicados:");
  autoresConLibrosPublicados.ForEach(z => Console.WriteLine("Id: {0} - Nombre: {1} NumeroLibros: {2} ", z.Id, z.Nombre, z.NumeroLibros));
}

void BorrarAutor(IDbConnection connection, string nombreAutor)
{
  Console.WriteLine($"Eliminando autor: {nombreAutor}");

  metodosAutor.BorrarAutor(connection, nombreAutor);
}

void MostrarAutor(IDbConnection connection, string nombreAutor)
{
  Console.WriteLine($"Buscando autor: {nombreAutor}");

  var autor = metodosAutor.DameAutor(connection, nombreAutor);

  if (autor != null)
  {
    Console.WriteLine("Id: {0} - Nombre: {1} ", autor.Id, autor.Nombre);
  }
  else
  {
    Console.WriteLine($"No se ha encontrado autor con nombre: {nombreAutor}");
  }
}

void BorrarLibro(IDbConnection connection, string titulo)
{
  Console.WriteLine($"Eliminando libro: {titulo}");

  metodosLibro.BorrarLibro(connection, titulo);
}

void MostrarLibro(IDbConnection connection, string titulo)
{
  Console.WriteLine($"Buscando libro: {titulo}");

  var libro = metodosLibro.DameLibro(connection, titulo);

  if (libro != null)
  {
    Console.WriteLine("Id: {0} - Titulo: {1} AñoPublicación: {2} Ventas: {3} IdAutor: {4}", libro.Id, libro.Titulo, libro.AnioPublicacion, libro.Ventas, libro.IdAutor);
  }
  else
  {
    Console.WriteLine($"No se ha encontrado libro con titulo: {titulo}");
  }
}

void ActualizarLibro(IDbConnection connection, int id, string titulo)
{
  Console.WriteLine($"Actualizando libro con Id: {id} a nuevo titulo: {titulo}");

  metodosLibro.ActualizarLibro(connection, id, titulo);
}