using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _39_ClasePersonaProfesorEstudiante
{
  public class EstudianteProfesorTest
  {
    public static void Main()
    {
      Persona random = new Persona();
      random.Saludar();

      Estudiante alumno = new Estudiante();
      alumno.SetEdad(21);
      alumno.Saludar();
      alumno.VerEdad();
      alumno.Estudiar();

      Profesor profe = new Profesor();
      profe.SetEdad(45);
      profe.Saludar();
      profe.Explicar();
    }
  }
}
