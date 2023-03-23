using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaObjetos
{
  public class Estudiante : Persona
  {
    public Estudiante(string nombre) : base(nombre) // Con base llamamos al constructor del padre y le pasamos por parámetro el nombre
    {
      this.nombre = nombre;
    }
    public void Estudiar()
    {
      Console.WriteLine("Estudiando");
    }
  }
}
