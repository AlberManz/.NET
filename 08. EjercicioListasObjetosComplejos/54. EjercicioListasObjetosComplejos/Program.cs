// -  Crear una entidad(clase) Vehículo con las propiedades (Marca, Combustible)
// -  Crear una entidad Coche que herede de vehículo y además tenga una propiedad NumeroPuertas
// -  Crear una entidad Camion que herede de vehículo y además tenga una propiedad CargaMaxima

// -  En Program.cs en Main vamos a crear:


using System.Xml.Serialization;
using _54._EjercicioListasObjetosComplejos.Entidades;

const string diesel = "Diesel";
const string gasolina95 = "Gasolina 95";
const string gasolina98 = "Gasolina 98";


// o   Listado de coches con 3 coches

var coches = new List<Coche>
{
  new Coche{ combustible = diesel, marca = "Opel Astra", numPuertas = 4 },
  new Coche{ combustible = gasolina98, marca = "Seat León", numPuertas = 3 },
  new Coche{ combustible = gasolina95, marca = "Wolkswagen Golf", numPuertas = 3 },
};


// o   Listado de camiones con 2 camiones
var camiones = new List<Camion>
{
  new Camion{ combustible=diesel, marca="Mercedes Actros", cargaMax = 5000 },
  new Camion{ combustible=diesel, marca="Scania 113", cargaMax = 5500 },
};



// o   Añadir un cuarto coche

coches.Add(new Coche { combustible = gasolina95, marca = "Audi", numPuertas = 3 });


// o   Borrar el coche de la posición 2 y sacar listado por pantalla
coches.RemoveAt(1);
MostrarCoches(coches);



// o   Crear una nueva lista de 2 camiones y añadir el rango al listado inicial de camiones. Sacar por pantalla, dicho listado

var camiones2 = new List<Camion>
{
  new Camion { combustible = diesel, marca = "Mercedes Sprinter", cargaMax = 3000 },
  new Camion { combustible = diesel, marca = "Scania 80", cargaMax = 3000 },
};
camiones.AddRange(camiones2);
MostrarCamiones(camiones);


// o   Filtrar la lista de coches por el numero de puertas que queramos  y sacar el resultado

var cochesMas3Puertas = coches.Where(x => x.numPuertas >= 3).ToList();
MostrarCoches(cochesMas3Puertas);


// o   Filtrar la lista de camiones por la carga máxima que queramos  y sacar el resultado

var camionesMas5000CargaMax = camiones.Where(x => x.cargaMax >= 5000).ToList();
MostrarCamiones(camionesMas5000CargaMax);



// o   Agrupar la lista de coches por el numero de puertas y sacar el resultado

var cochesNumPuertas = coches.GroupBy(x => x.numPuertas).ToList();
foreach (var cocheNumPuertas in cochesNumPuertas)
{
  Console.WriteLine($"Coches con número de puertas {cocheNumPuertas.Key}");
  MostrarCoches((cocheNumPuertas.ToList()));
}



// o   Agrupar la lista de camiones por la carga máxima y sacar el resultado

var camionesCargaMax = camiones.GroupBy(x => x.cargaMax).ToList();
foreach (var camionCargaMax in camionesCargaMax)
{
  Console.WriteLine($"Camiones con carga máxima {camionCargaMax.Key}");
  MostrarCamiones(camionCargaMax.ToList());
}



// MÉTODOS para mostrar coches y camiones

void MostrarCoches(List<Coche> coches)
{

  foreach (var coche in coches)
  {
    Console.WriteLine($"Coche: {coche.marca}, Combustible: {coche.combustible}, Puertas: {coche.numPuertas}");
  }
}

void MostrarCamiones(List<Camion> camiones)
{

  foreach (var camion in camiones)
  {
    Console.WriteLine($"Coche: {camion.marca}, Combustible: {camion.combustible}, Puertas: {camion.cargaMax}");
  }
}
