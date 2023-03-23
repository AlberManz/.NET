using Dapper.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Logica
{
    public interface IMetodosLibro
    {
        void LimpiaDatosLibros(IDbConnection connection);
        int InsertarLibros(IDbConnection connection, List<Libro> libros);
        int BorrarLibro(IDbConnection connection, string titulo);
        int ActualizarLibro(IDbConnection connection, int id, string titulo);
        List<Libro> DameTodosLosLibros(IDbConnection connection);
        Libro DameLibro(IDbConnection connection, int id);
        Libro DameLibro(IDbConnection connection, string titulo);
    }
}
