using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaObjetos
{
  public class Persona
  {
    public string nombre { get; set; }
    public Persona(string nombre)
    {
      this.nombre = nombre;
    }

    public override string ToString()
    {
      return $"Hola {nombre}";
    }
  }
}
