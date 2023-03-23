using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Requests
{
  public class UpdateArtistaRequest
  {
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public string Pais { get; set; }
  }
}
