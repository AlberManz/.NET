// Crea un programa en C# que implemente una interfaz IVehiculo con dos métodos, uno para Conducir de tipo void y otro para Repostar de tipo bool
// que tenga un parámetro de tipo entero con la cantidad de gasolina a repostar. Después cree una clase Coche con un constructor que reciba un parámetro
// con la cantidad de gasolina inicial del coche y implemente los métodos de Conducir y Repostar el coche.

// El método Conducir imprimirá en pantalla que el coche está Conduciendo, si la gasolina es mayor a 0.
// El método Repostar aumentará la gasolina del coche y retornará´verdadero.

// Para realizar las pruebas cree un objeto de tipo Coche con 0 de gasolina en el Main del programa y solicite al usuario una cantidad de gasolina
// para repostar, por último ejecute el método Conducir del coche.

using _49_Interfaces;

var coche = new Coche(0);

var gasolinaRepostar = Convert.ToInt32(Console.ReadLine());
if (coche.Repostar(gasolinaRepostar))
{
  coche.Conducir();
}
else
{
  Console.WriteLine("Coche sin gasolina");
}

