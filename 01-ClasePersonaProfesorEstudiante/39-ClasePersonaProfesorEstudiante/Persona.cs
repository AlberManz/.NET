using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _39_ClasePersonaProfesorEstudiante
{
  internal class Persona
  {
    protected int Edad { get; set; } // Con protected solo pueden acceder las clases que hereden de la clase
    public void Saludar()
    {
      Console.WriteLine("Hoola");
    }

    public void SetEdad(int edad)
    {
      if (edad <= 0)
      {
        Console.WriteLine("Debes ser mayor de 0 años");
      }
      else
      {
        Edad = edad;
      }
    }
  }
}
