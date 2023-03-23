using Dapper.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Logica
{
    public interface IMetodosAutor
    {
        void LimpiaDatosAutores(IDbConnection connection);
        int InsertaAutor(IDbConnection connection, Autor autor);
        List<AutorExtendido> ObtenerAutoresConLibrosPublicados(IDbConnection connection, string nombreAutor);
        int BorrarAutor(IDbConnection connection, string nombreAutor);
        List<Autor> DameTodosAutores(IDbConnection connection);
        Autor DameAutor(IDbConnection connection, int id);
        Autor DameAutor(IDbConnection connection, string nombreAutor);
    }
}
