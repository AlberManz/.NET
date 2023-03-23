using Dapper.Entidades;
using Dapper.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Dapper.Servicios
{
  public class MetodosLibro : IMetodosLibro
  {
    public int ActualizarLibro(IDbConnection connection, int id, string titulo)
    {
      var sqlQueryUpdate = @"UPDATE Libros set Titulo = @Titulo
                            WHERE id = @id;";

      return connection.Execute(sqlQueryUpdate, new
      {
        Titulo = titulo,
        id = id
      });
    }

    public int BorrarLibro(IDbConnection connection, string titulo)
    {


      var sqlQueryDelete = @"Delete from Libros WHERE Titulo = @Titulo;";
      return connection.Execute(sqlQueryDelete, new
      {
        Titulo = titulo
      });
    }

    public Libro DameLibro(IDbConnection connection, int id)
    {
      throw new NotImplementedException();
    }

    public Libro DameLibro(IDbConnection connection, string titulo)
    {
      return connection.Query<Libro>("Select * from Libros WHERE Titulo = @Titulo", new
      {
        Titulo = titulo
      }).FirstOrDefault();
    }

    public List<Libro> DameTodosLosLibros(IDbConnection connection)
    {
      return connection.Query<Libro>("Select * from Libros").ToList();
    }

    public int InsertarLibros(IDbConnection connection, List<Libro> libros)
    {
      var insertLibroSql = @"INSERT INTO dbo.[Libros](Titulo, AnioPublicacion, Ventas, IdAutor)
                             OUTPUT INSERTED.*
                             VALUES(@Titulo, @AnioPublicacion, @Ventas, @IdAutor);";

      var filasInsertadas = connection.Execute(insertLibroSql, libros); // Dapper nos permite ahorranos el bucle foreach porque mappea la clase libros y 
      // al tener los mismos campos podemos hacer un connection.Execute pasando la query y los libros

      return filasInsertadas;
    }

    public void LimpiaDatosLibros(IDbConnection connection)
    {
      var libro = connection.Query<Libro>("Select * from Libros");

      var sqlQueryLimpiar = @"TRUNCATE TABLE LIBROS;";

      connection.Execute(sqlQueryLimpiar);
    }
  }
}
