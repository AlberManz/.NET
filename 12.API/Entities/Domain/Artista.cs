using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Domain
{
  public class Artista
  {
    public int Id { get; set; }
    public string? Nombre { get; set; } // La interrogación en string es porque puede que nos nos metan el nombre, para dar esa posibilidad
    public int Edad { get; set; }
    public string Pais { get; set; }
  }
}
