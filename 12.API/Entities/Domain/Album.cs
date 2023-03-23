using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Domain
{
  public class Album
  {
    public int Id { get; set; }
    public int ArtistaId { get; set; }
    public Artista? Artista { get; set; }

    public string? Titulo { get; set; }
    public decimal Precio { get; set; }
    public int Anio { get; set; }
  }
}
