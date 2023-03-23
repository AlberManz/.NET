using System;
using System.Collections.Generic;

namespace _64.EFCore.DataBaseFirst.Models
{
    public partial class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public int AnioPublicacion { get; set; }
        public int Ventas { get; set; }
        public int AutorId { get; set; }
        public string Tematica { get; set; } = null!;
        public string? Resumen { get; set; }

        public virtual Autore Autor { get; set; } = null!;
    }
}
