using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Entidades
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int IdAutor { get; set; }
        public int AnioPublicacion { get; set; }
        public int Ventas { get; set; }
    }
}
