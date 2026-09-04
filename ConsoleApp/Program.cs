using AccesoDatos.Models;
using AccesoDatos.Repositories;

IGenericRepository<Autor> autorRepository = new GenericRepository<Autor>();
IGenericRepository<Libro> libroRepository = new GenericRepository<Libro>();
IGenericRepository<Categoria> categoriaRepository = new GenericRepository<Categoria>();
bool continuar = true;

{
	
	while (continuar)
	{
		Console.WriteLine("================================");
		Console.WriteLine(" SISTEMA DE BIBLIOTECA ");
		Console.WriteLine("================================");
		Console.WriteLine("1. Alta Autor");
		Console.WriteLine("2. Alta Categoria");
		Console.WriteLine("3. Alta Libro");
		Console.WriteLine("4. Ver Autores");
		Console.WriteLine("5. Ver Categorias");
		Console.WriteLine("6. Ver Libros");
		Console.WriteLine("7. Modificar Autor");
		Console.WriteLine("8. Modificar Libro");
		Console.WriteLine("9. Eliminar Libro");
		Console.WriteLine("0. Salir");
		Console.WriteLine();

		Console.Write("Seleccione una opción: ");
		string opcion = Console.ReadLine();

		Console.Clear();

		switch (opcion)
		{
			case "1":
				AltaAutor();
				break;

			case "2":
				AltaCategoria();
				break;
			
			
			case "3":
				AltaLibro();
				break;

			case "4":
				VerAutores();
				break;

			case "5":
				VerCategoria();
				break;

			case "6":
				MostrarLibros();
				break;

			case "7":
				ModificarAutor();
				break;

			case "8":
				ModificarLibro();
				break;

			case "9":
				EliminarLibro();
				break;

			case "0":
				continuar = false;
				Console.WriteLine("Aplicación finalizada.");
				break;

			default:
				Console.WriteLine("Opción inválida.");
				PresioneParaContinuar();
				break;
		}
	}

	void AltaAutor()
	{
		Console.Write("Nombre del autor: ");

		string nombre = Console.ReadLine();

		Autor autor = new Autor
		{
			Nombre = nombre
		};

		autorRepository.Agregar(autor);

		Console.WriteLine("Autor registrado correctamente.");

		PresioneParaContinuar();
	}

	void AltaLibro()
	{
		Console.Write("Título: ");
		string titulo = Console.ReadLine();

		Console.Write("Año publicación: ");
		int anio = int.Parse(Console.ReadLine());

		Console.WriteLine();
		Console.WriteLine("Autores disponibles:");

		var autores = autorRepository.ObtenerTodos();

		foreach (var autor in autores)
		{
			Console.WriteLine(
				$"ID: {autor.Id} - {autor.Nombre}");
		}

		Console.WriteLine();

		Console.Write("Seleccione el ID del autor: ");

		int autorId = int.Parse(Console.ReadLine());

		Libro libro = new Libro
		{
			Titulo = titulo,
			AnioPublicacion = anio,
			AutorId = autorId
		};

		libroRepository.Agregar(libro);

		Console.WriteLine("Libro registrado correctamente.");

		PresioneParaContinuar();
	}

	void AltaCategoria ()
	{
		Console.WriteLine("Nombre de la categoria: ");
		string nombre = Console.ReadLine();
		Categoria categoria = new Categoria { Nombre = nombre };
		Console.WriteLine("Categoría registrada correctamente.");
		PresioneParaContinuar();

	}

	void VerAutores() 
	{
		Console.WriteLine("===== LISTADO DE AUTORES =====");
		var autores = libroRepository.ObtenerTodos();
		if (autores != null)
		{
			Console.WriteLine("No existen autores registrados.");
		}
		else
		{
			foreach (var autor in autores)
			Console.WriteLine($"ID: {autor.Id} -- Nombre: {autor.Autor.Nombre}");
		}	
			PresioneParaContinuar();
	}

	void VerCategoria() 
	{
		Console.WriteLine("===== LISTADO DE LIBROS =====");
		var categorias = categoriaRepository.ObtenerTodos();
		if (categorias!=null)
		{
			Console.WriteLine("No existen categorías registradas.");
		}
		else
		{
			foreach (var categoria in categorias)
			Console.WriteLine($"ID: {categoria.Id} - {categoria.Nombre}");
		}
		PresioneParaContinuar();

	}

	void MostrarLibros()
	{
		Console.WriteLine("===== LISTADO DE LIBROS =====");

		var libros = libroRepository.ObtenerTodosCon("Autor");

		if (!libros.Any())
		{
			Console.WriteLine("No existen libros registrados.");
		}
		else
		{
			foreach (var libro in libros)
			{
				Console.WriteLine($"ID: {libro.Id} | Título: {libro.Titulo} | Año: {libro.AnioPublicacion} " +
					$"| Autor: {libro.Autor.Nombre}");
			}
		}

		Console.WriteLine("=============================");

		PresioneParaContinuar();

	}

	void ModificarAutor()
	{
		Console.WriteLine("===== MODIFICAR AUTOR =====");

		var autores = autorRepository.ObtenerTodos();

		if (!autores.Any())
		{
			Console.WriteLine("No existen autores registrados.");
			PresioneParaContinuar();
			return;
		}

		foreach (var autor in autores)
		{
			Console.WriteLine($"ID: {autor.Id} - {autor.Nombre}");
		}

		Console.WriteLine();
		Console.Write("Seleccione el ID del autor a modificar: ");
		int id = int.Parse(Console.ReadLine());

		var autorExistente = autorRepository.ObtenerPorId(id);

		if (autorExistente == null)
		{
			Console.WriteLine("Autor no encontrado.");
			PresioneParaContinuar();
			return;
		}

		Console.Write($"Nuevo nombre (actual: {autorExistente.Nombre}): ");
		string nuevoNombre = Console.ReadLine();

		if (!string.IsNullOrWhiteSpace(nuevoNombre))
		{
			autorExistente.Nombre = nuevoNombre;
			autorRepository.Modificar(autorExistente);
			Console.WriteLine("Autor modificado correctamente.");
		}
		else
		{
			Console.WriteLine("Nombre inválido, no se realizaron cambios.");
		}
	}

	void ModificarLibro()
	{ 
		Console.WriteLine("===== MODIFICAR lIBRO =====");
		var libros = libroRepository.ObtenerTodosCon("Autor");

		if (!libros.Any())
		{
			Console.WriteLine("No existen libros registrados.");
		}
		foreach (var libro in libros)
		{
				Console.WriteLine($"ID: {libro.Id} | Título: {libro.Titulo} | Año: {libro.AnioPublicacion} " +
					$"| Autor: {libro.Autor.Nombre}");
		}

		Console.WriteLine();
		Console.Write("Seleccione el ID del libro a modificar: ");
		int id = int.Parse(Console.ReadLine());

		var libroExistente = libroRepository.ObtenerPorId(id);

		if (libroExistente == null)
		{
			Console.WriteLine("Libro no encontrado.");
			PresioneParaContinuar();
			return;
		}

		Console.Write($"Nuevo título (actual: {libroExistente.Titulo}): ");
		string nuevoTitulo = Console.ReadLine();

		Console.Write($"Nuevo año (actual: {libroExistente.AnioPublicacion}): ");
		string nuevoAnioStr = Console.ReadLine();

		if (!string.IsNullOrWhiteSpace(nuevoTitulo))
		{
			libroExistente.Titulo = nuevoTitulo;
		}

		if (int.TryParse(nuevoAnioStr, out int nuevoAnio))
		{
			libroExistente.AnioPublicacion = nuevoAnio;
		}

		libroRepository.Modificar(libroExistente);
		Console.WriteLine("Libro modificado correctamente.");

		PresioneParaContinuar();
	}

	void EliminarLibro()
	{
		Console.WriteLine("===== ELIMINAR LIBRO =====");
		var Libros = libroRepository.ObtenerTodosCon("Autor");
		if (Libros == null)
		{
			Console.WriteLine("Libro no encontrado.");
			PresioneParaContinuar();
			return;
		}
		foreach (var libro in Libros)
		{
			Console.WriteLine($"ID: {libro.Id} | Título: {libro.Titulo} | Año: {libro.AnioPublicacion} " +
				$"| Autor: {libro.Autor.Nombre}");
		}

		Console.WriteLine();
		Console.Write("Seleccione el ID del libro a eliminar: ");
		int id = int.Parse(Console.ReadLine());

		var libroExistente = libroRepository.ObtenerPorId(id);

		if (libroExistente == null)
		{
			Console.WriteLine("Libro no encontrado.");
			PresioneParaContinuar();
			return;
		}

		Console.Write($"¿Confirma eliminar \"{libroExistente.Titulo}\"? (S/N): ");
		string confirmacion = Console.ReadLine();
		libroRepository.Eliminar(id);
		Console.WriteLine("Libro eliminado correctamente.");

		PresioneParaContinuar();
	}



	void PresioneParaContinuar()
	{
		Console.WriteLine();
		Console.WriteLine("Presione una tecla para continuar...");
		Console.ReadKey();
		Console.Clear();
	}
	PresioneParaContinuar();

}