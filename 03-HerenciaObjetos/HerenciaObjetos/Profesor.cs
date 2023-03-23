using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaObjetos
{
  public class Profesor : Persona
  {
    public Profesor(string nombre) : base(nombre)
    {
      this.nombre = nombre;
    }
    public void Explicar()
    {
      Console.WriteLine("Explicando");
    }
  }
}
