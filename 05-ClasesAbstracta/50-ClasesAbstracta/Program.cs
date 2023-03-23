// Crea un programa en C# que implemente una clase abstracta Animal que tenga una propiedad Nombre de tipo texto y tres métodos SetNombre(string nombre),
// GetNombre y Comer. El método Comer será un método abstracto de tipo void.

// Además deberá crear una clase Perro que implemente la clase anterior Animal y el método Comer que diga que el perro está Comiendo.

// Para probar el programa solicite un nombre de perro al usuario y cree un nuevo objeto de tipo Perro desde el Main del programa,
// asigne el nombre al objeto Perro y luego ejecute los métodos GetNombre y Comer.

using _50_ClasesAbstracta;

var perro = new Perro();
perro.SetNombre(Console.ReadLine());
Console.WriteLine(perro.GetNombre());
perro.Correr();
