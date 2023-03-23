// Cree un nuevo proyecto en C# con tres clases más otra clase para probar la lógica del código.
// Las clases principales del programa son las siguientes clases:
// · Persona
// · Estudiante
// · Profesor

// Las clases de Estudiante y Profesor heredan de la clase Persona.
// La clase Estudiante incluirá un método público Estudiar() que escribirá en pantalla: Estoy estudiando.
// La clase Persona debe tener dos métodos público Saludar() y SetEdad(int edad) que asignará la edad de la persona.
// La clase Profesor incluirá un método público Explicar() que escribirá en pantalla: Estoy explicando.
// Además crea un método público VerEdad() en la clase Estudiante que escriba en pantalla Mi edad es: x años.

// Debe crear otra clase de prueba llamada EstudianteProfesorTest con un método Main para realizar las siguientes acciones:

// ·         Crear una nueva Persona y hacer que salude
// ·         Crear una nuevo Estudiante, establecer una edad cualquiera, hacer que salude, mostrar su edad en pantalla y empezar a estudiar.
// ·         Crear un nuevo Profesor, establecer una edad cualquiera, saludar y empezar la explicación.

// Entrada
// 1.
// Salida
// 1.   ¡Hola!
// 2.   ¡Hola!
// 3.   Mi edad es 21 años
// 4.   Estoy estudiando
// 5.   ¡Hola!
// 6.   Estoy explicando


// El Program.cs ejecuta
using _39_ClasePersonaProfesorEstudiante;

var EstudianteProfesorTest = new EstudianteProfesorTest();
EstudianteProfesorTest.Main(); // Ejecutamos el Main de EstudianteProfesorTest
