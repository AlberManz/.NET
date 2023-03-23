// Crear una lista de tipo int e inicializarla con los valores 1, 2 y 3

// Crear una segunda lista de tipo int e inicializarla con los valores 4, 5 y 6
//
// Añadir a la primera lista los valores de la segunda

// Sacar por pantalla cada uno de los valores de la primera lista

// Sacar por pantalla el numero de elementos de cada lista

// Borrar el valor 1 de la lista final y sacar valores por pantalla
//    Por pantalla saldrá 2,3,4,5,6

// Borrar el valor de la posición 2 de la lista final y sacar valores por pantalla
//    Por pantalla saldrá 2,3,5 y 6

// Añadir el valor 1 a la lista final y sacar por pantalla los valores 
//    Por pantalla saldrá 2,3,5, 6 y 1

// Ordenar los valores de la lista final y sacarlos por pantalla
//    Por pantalla saldrá 1, 2,3,5 y 6


List<int> list = new List<int> { 1, 2, 3 };
List<int> list2 = new List<int> { 4, 5, 6 };

list.AddRange(list2);

MostrarLista(list);

Console.WriteLine($"La lista tiene {list.Count} elementos");
Console.WriteLine($"La lista2 tiene {list2.Count} elementos");

list.Remove(1);
MostrarLista(list);

list.RemoveAt(2);
MostrarLista(list);

list.Add(1);
MostrarLista(list);

MostrarLista(list.OrderBy(x => x).ToList()); // Ordenando elementos

void MostrarLista(List<int> ints)
{
  foreach (var i in ints)
  {
    Console.Write(i + " ");
  }
  Console.WriteLine();
}
