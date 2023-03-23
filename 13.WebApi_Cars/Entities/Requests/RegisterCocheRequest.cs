using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Requests
{
  public class RegisterCocheRequest
  {
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Version { get; set; }
  }
}
