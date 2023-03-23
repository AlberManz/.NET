// Crea un programa en C# que solicite tres nombres de personas al usuario y los almacene en un array de objetos de tipo Persona.

// Habrán dos personas de tipo Estudiante y una persona de tipo Profesor.

// Para ello crea una clase Persona que tenga una propiedad Nombre de tipo string, un constructor que reciba el nombre como parámetro y sobrescriba
// el método ToString().

// Después cree dos clases más que hereden de la clase Persona, se llamarán Estudiante y Profesor.

// La clase Estudiante tiene un método Estudiar que escribe por consola que el estudiante está estudiando.

// La clase Profesor tendrá un método Explicar que escribe en consola que el profesor está explicando.

// Recuerde crear además dos constructores en las clases hijas que llamen al constructor padre de la clase Persona.

// Finalice el programa leyendo las personas (el profesor y los alumnos) y ejecute los métodos de Explicar y Estudiar.


using HerenciaObjetos;

int total = 3;
Persona[] persona = new Persona[total];

for (int i = 0; i < total; i++)
{
  if (i == 0)
  {
    persona[i] = new Profesor(Console.ReadLine());
  }
  else
  {
    persona[i] = new Estudiante(Console.ReadLine());
  }
}
for (int i = 0; i < total; i++)
{
  if (i == 0)
  {
    ((Profesor)persona[i]).Explicar(); // Estamos transformando persona[i] a Profesor que al ser una clase creada por nosotros y heradada funciona
  }
  else
  {
    ((Estudiante)persona[i]).Estudiar();
  }
}


