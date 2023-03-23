using System;
using System.Collections.Generic;

namespace _64.EFCore.DataBaseFirst.Models
{
    public partial class Autore
    {
        public Autore()
        {
            Libros = new HashSet<Libro>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
