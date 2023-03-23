using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _50_ClasesAbstracta
{
  public abstract class Animal
  {
    protected string nombre;

    public void SetNombre(string nombre)
    {
      this.nombre = nombre;
    }

    public string GetNombre()
    {
      return this.nombre;
    }

    public abstract void Correr();
  }

}
