using Dapper.Entidades;
using Dapper.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Servicios
{
  public class MetodosAutor : IMetodosAutor
  {
    public int BorrarAutor(IDbConnection connection, string nombreAutor)
    {
      string sqlQueryDelete = @"Delete from Autores WHERE Nombre = @Nombre";
      return connection.Execute(sqlQueryDelete, new
      {
        Nombre = nombreAutor
      });
    }

    public Autor DameAutor(IDbConnection connection, int id)
    {
      throw new NotImplementedException();
    }

    public Autor DameAutor(IDbConnection connection, string nombreAutor)
    {
      return connection.Query<Autor>("Select * from Autores WHERE Nombre = @Nombre", new
      {
        Nombre = nombreAutor
      }).FirstOrDefault();
    }

    public List<Autor> DameTodosAutores(IDbConnection connection)
    {
      List<Autor> autores = new List<Autor>();
      autores = connection.Query<Autor>("Select * from Autores").ToList();
      return autores;

      // VERSIÓN PRO return connection.Query<Autor>("Select * from Autores").ToList();
    }

    public int InsertaAutor(IDbConnection connection, Autor autor)
    {
      var insertAutorSql = @"INSERT INTO dbo.[Autores](Nombre)
                            OUTPUT INSERTED.*
                            VALUES(@Nombre);";

      var newAutor = connection.QuerySingle<Autor>(insertAutorSql,
        new
        {
          Nombre = autor.Nombre
        });
      return newAutor.Id;
    }

    public void LimpiaDatosAutores(IDbConnection connection)
    {
      var autor = connection.Query<Autor>("Select * from Autores").FirstOrDefault();

      string sqlQueryLimpiar = @"TRUNCATE TABLE AUTORES;";

      connection.Execute(sqlQueryLimpiar);
    }

    public List<AutorExtendido> ObtenerAutoresConLibrosPublicados(IDbConnection connection, string nombreAutor)
    {
      return connection.Query<AutorExtendido>("select COUNT(libro.IdAutor) as NumeroLibros, autor.Id, autor.Nombre " +
                                              "from Autores autor " +
                                              "inner join Libros libro on libro.IdAutor = autor.Id " +
                                              "where autor.Nombre=@Nombre " +
                                              "group by libro.IdAutor, autor.Id, autor.Nombre",
        new
        {
          Nombre = nombreAutor
        }).ToList();
    }
  }
}
