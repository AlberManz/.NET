using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _39_ClasePersonaProfesorEstudiante
{
  internal class Estudiante : Persona
  {

    public void Estudiar()
    {
      Console.WriteLine("Estoy estudiando");
    }

    public void VerEdad()
    {
      Console.WriteLine($"Mi edad es {Edad}");
    }
  }

}
