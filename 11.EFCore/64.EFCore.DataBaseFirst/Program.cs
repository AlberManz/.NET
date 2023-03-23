// See https://aka.ms/new-console-template for more information

//Hay que situarse desde el Package Manager Console en el directorio donde está el proyecto que queremos usar con EF
//Si da error de versión de dotnet tools ejecutar el siguiente comando y después reiniciar Visual Studio:
//dotnet tool update --global dotnet-ef

//Una vez no de error, ejecutar el siguiente comando, cada vez que queramos actualizar nuestro código de C# con respecto a la BD
//Scaffold-DbContext "Server=.\SQLEXPRESS;Initial Catalog=EjercicioEFCore;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -force

using _64.EFCore.DataBaseFirst.Models;

using (var context = new EjercicioEFCore2Context())
{
	var autores = context.Autores.ToList();
}
