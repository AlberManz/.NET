// See https://aka.ms/new-console-template for more information

using EF.Core.Entidades.Autores;
using EF.Core.Entidades.Libros;
using EFCore.Services;

IMetodosAutor metodosAutor = new MetodosAutor();
IMetodosLibro metodosLibro = new MetodosLibro();

using (var context = new DatabaseContext())
{
	LimpiarDatosInicialesDB(context);

	InsertaDatosIniciales(context);

	MostrarDatosAutores(context);

	MostrarDatosLibros(context);

	MostrarDatosAutorLibrosPublicados(context, "J. R. R. Tolkien");

	BorrarAutor(context, "Charles Dickens");

	MostrarAutor(context, "Charles Dickens");

	BorrarLibro(context, "El hobbit");

	MostrarLibro(context, "El hobbit");

	var libro = metodosLibro.DameLibro(context, "Don Quijote de la Mancha Version 2");

	ActualizarLibro(context, libro.Id, "Don Quijote de la Mancha");

	MostrarLibro(context, "Don Quijote de la Mancha");

	MostrarLibrosTematica(context, "Aventura");

	void MostrarLibrosTematica(DatabaseContext context, string tematica)
	{
		Console.WriteLine("Mostrando datos de Libros en BD");

		var libros = metodosLibro.DameTodosLosLibros(context, tematica);
		libros.ForEach(z => Console.WriteLine("Id: {0} - Titulo: {1} AñoPublicación: {2} Ventas: {3} IdAutor: {4} Tematica: {5}", z.Id, z.Titulo, z.AnioPublicacion, z.Ventas, z.Autor.Id, z.Tematica));
	}

	void LimpiarDatosInicialesDB(DatabaseContext context)
	{
		metodosAutor.LimpiaDatosAutores(context);
		metodosLibro.LimpiaDatosLibros(context);
	}

	void InsertaDatosIniciales(DatabaseContext context)
	{
		Console.WriteLine("Insertando datos iniciales...");

		var autoresCSV = File.ReadAllLines("CSVs\\Import\\Autores.csv");
		List<Autor> autores = new List<Autor>();

		for (int i = 1; i < autoresCSV.Length; i++)
		{
			string autorCSV = autoresCSV[i];
			var autorCSVSplited = autorCSV.Split(';');
			autores.Add(new Autor { Nombre = autorCSVSplited[1] });
		}

		foreach (var autor in autores)
		{
			metodosAutor.InsertaAutor(context, autor);
		}

		var librosCSV = File.ReadAllLines("CSVs\\Import\\Libros.csv");
		List<Libro> libros = new List<Libro>();

		for (int i = 1; i < librosCSV.Length; i++)
		{
			string libroCSV = librosCSV[i];
			var libroCSVSplited = libroCSV.Split(';');

			var autor = autores.Where(x => x.Id == int.Parse(libroCSVSplited[2])).FirstOrDefault();

			libros.Add(new Libro
			{
				Titulo = libroCSVSplited[1],
				AnioPublicacion = int.Parse(libroCSVSplited[3]),
				Ventas = int.Parse(libroCSVSplited[4]),
				Tematica = libroCSVSplited[5],
				Autor = autor
			});
		}

		metodosLibro.InsertarLibros(context, libros);

		Console.WriteLine("Datos iniciales insertados...");
	}

	void MostrarDatosAutores(DatabaseContext context)
	{
		Console.WriteLine("Mostrando datos de Autores en BD");

		var autores = metodosAutor.DameTodosAutores(context);
		autores.ForEach(z => Console.WriteLine("Id: {0} - Nombre: {1} ", z.Id, z.Nombre));

	}

	void MostrarDatosLibros(DatabaseContext context)
	{
		Console.WriteLine("Mostrando datos de Libros en BD");

		var libros = metodosLibro.DameTodosLosLibros(context);
		libros.ForEach(z => Console.WriteLine("Id: {0} - Titulo: {1} AñoPublicación: {2} Ventas: {3} IdAutor: {4}", z.Id, z.Titulo, z.AnioPublicacion, z.Ventas, z.Autor.Id));
	}

	void MostrarDatosAutorLibrosPublicados(DatabaseContext context, string nombreAutor)
	{
		var autoresConLibrosPublicados = metodosAutor.ObtenerAutoresConLibrosPublicados(context, nombreAutor);

		Console.WriteLine("Autores con Libros Publicados:");
		autoresConLibrosPublicados.ForEach(z => Console.WriteLine("Id: {0} - Nombre: {1} NumeroLibros: {2} ", z.Id, z.Nombre, z.NumeroLibros));

		var path = $"CSVs//Export";

		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}

		path += $"//{DateTime.Now.ToString("yyyyMMddhhmmss")}-AutoresConLibrosPublicados.csv";

		File.AppendAllText(path, "Id;Nombre;NumeroLibros");
		File.AppendAllText(path, Environment.NewLine);

		foreach (var autorConLibros in autoresConLibrosPublicados)
		{
			File.AppendAllText(path, $"{autorConLibros.Id};{autorConLibros.Nombre};{autorConLibros.NumeroLibros}");
			File.AppendAllText(path, Environment.NewLine);
		}
	}

	void BorrarAutor(DatabaseContext context, string nombreAutor)
	{
		Console.WriteLine($"Eliminando autor: {nombreAutor}");

		metodosAutor.BorrarAutor(context, nombreAutor);
	}

	void MostrarAutor(DatabaseContext context, string nombreAutor)
	{
		Console.WriteLine($"Buscando autor: {nombreAutor}");

		var autor = metodosAutor.DameAutor(context, nombreAutor);

		if (autor != null)
		{
			Console.WriteLine("Id: {0} - Nombre: {1} ", autor.Id, autor.Nombre);
		}
		else
		{
			Console.WriteLine($"No se ha encontrado autor con nombre: {nombreAutor}");
		}
	}

	void BorrarLibro(DatabaseContext context, string titulo)
	{
		Console.WriteLine($"Eliminando libro: {titulo}");

		metodosLibro.BorrarLibro(context, titulo);
	}

	void MostrarLibro(DatabaseContext context, string titulo)
	{
		Console.WriteLine($"Buscando libro: {titulo}");

		var libro = metodosLibro.DameLibro(context, titulo);

		if (libro != null)
		{
			Console.WriteLine("Id: {0} - Titulo: {1} AñoPublicación: {2} Ventas: {3} IdAutor: {4}", libro.Id, libro.Titulo, libro.AnioPublicacion, libro.Ventas, libro.Autor.Id);
		}
		else
		{
			Console.WriteLine($"No se ha encontrado libro con titulo: {titulo}");
		}
	}	

	void ActualizarLibro(DatabaseContext context, int id, string titulo)
	{
		Console.WriteLine($"Actualizando libro con Id: {id} a nuevo titulo: {titulo}");

		metodosLibro.ActualizarLibro(context, id, titulo);
	}
}