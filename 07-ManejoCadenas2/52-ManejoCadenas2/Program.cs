// A partir de una cadena de texto “Estoy probando implementaciones de cadenas”, sacar:
//  - Longitud total de la cadena
//  - Numero de palabras
//  - Sacar por pantalla la frase “Estoy estudiando implementaciones de cadenas”
//  - Sacar por pantalla la posición de la palabra implementaciones
//  - Sacar por pantalla el número de caracteres de la palabra implementaciones

var cadena = "Estoy probando implementaciones de cadenas";

Console.WriteLine(cadena.Length);
Console.WriteLine(cadena.Split(' ').Length);
Console.WriteLine(cadena.Replace("probando", "estudiando"));

var cadenaSplit = cadena.Split(" ");
//for (int i = 0; i < cadenaSplit.Length; i++)
//{
//  if (cadenaSplit[i] == "implementaciones")
//  {
//    Console.WriteLine($"Posición de implementaciones: {i + 1}");
//  }
//}
var posicion = Array.IndexOf(cadenaSplit, "implementaciones"); // La transformamos a Array, vamos a su índice de qué variable y le decimos qué valor buscamos
Console.WriteLine($"Implementaciones está en la posición {posicion + 1}");
Console.WriteLine($"Implementaciones tiene {cadenaSplit[posicion].ToCharArray().Length} caracteres"); // De la variable cadenaSplit vamos a la posición
                                                                                                      // que hemos buscado que corresponde a
                                                                                                      // "implementaciones", lo pasamos a CharArray que
                                                                                                      // nos lo divide en letras y lo contamos



