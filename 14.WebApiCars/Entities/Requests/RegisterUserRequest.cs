using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Requests
{
  public class RegisterUserRequest
  {
    public string Nombre { get; set; }
    public string Email { get; set; }

    public string Password { get; set; }

    public int Rol { get; private set; }

    public RegisterUserRequest() // Constructor que por defecto lo ponga como Rol = 2 que es el user convencional (Admin el 1) creados en la tabla en Bd a mano
    {
      Rol = 2;
    }

  }
}
