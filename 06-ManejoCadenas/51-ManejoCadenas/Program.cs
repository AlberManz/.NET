// Teniendo una cadena que sea “Hola”:
// -          Concatenar una frase que saque por pantalla “La tercera letra de Hola es l”
// -          Sacar la frase por pantalla “La longitud de Hola es 4”
// -          Sacar la frase por pantalla “Una subcadena de Hola es ola”
// -          A partir de la frase “Estoy dando clase de .NET”, sacar por pantalla la frase “Estoy dando la clase de Angular”
// -          Con la frase “Estoy dando clase de .NET” sacar por pantalla “ESTOY dando CLASE de .NET”
// -          Sacar por pantalla el numero total de palabras que componen la frase “Estoy dando clase de .NET” -> “La frase ‘Estoy dando clase de .NET’ tiene 5 palabras”
// -          Sacar por pantalla la posición de la palabra .NET -> “’.NET’ es la palabra número 5 de la frase ‘Estoy dando clase de .NET’”

string cadena = "Hola";

Console.WriteLine($"La tercera letra de {cadena} es {cadena[2]}");

Console.WriteLine($"La longitud de {cadena} es {cadena.Length}");

Console.WriteLine($"Una subcadena de {cadena} es {cadena.Substring(1, 3)}");

string frase = "Estoy dando clase de .NET";

Console.WriteLine(frase.Replace("clase de.NET", "la clase de Angular"));
Console.Write(frase.Replace("estoy", "ESTOY").Replace("clase", "CLASE"));


Console.WriteLine($"La frase {frase} tiene {frase.Split(' ').Length} palabras");

var fraseSplit = frase.Split(' ');

for (int i = 0; i < fraseSplit.Length; i++)
{
  if (fraseSplit[i] == ".NET")
  {
    Console.WriteLine($"'.NET' es la palabra número {i + 1} de la frase '{frase}'");
  }
}
