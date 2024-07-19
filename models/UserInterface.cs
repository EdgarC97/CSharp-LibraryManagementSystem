using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.models;

// Defino la clase UserInterface que maneja la interacción con el usuario
public class UserInterface
{
    // Campo privado que almacena la instancia de la biblioteca
    private Library _library;

    // Constructor que inicializa el campo _library con la instancia proporcionada
    public UserInterface(Library library)
    {
        _library = library;
    }

    // Método principal que ejecuta el menú de la aplicación
    public void Run()
    {
        bool exit = false; // Bandera para controlar la salida del bucle
        while (!exit)
        {
            // Limpio la consola para una presentación más limpia del menú
            Console.Clear();
            // Muestro el menú de opciones al usuario
            Console.WriteLine("=== Sistema de Gestión de Biblioteca ===");
            Console.WriteLine("1. Agregar libro");
            Console.WriteLine("2. Eliminar libro");
            Console.WriteLine("3. Buscar libros por autor");
            Console.WriteLine("4. Buscar libros por género");
            Console.WriteLine("5. Buscar libros por rango de años");
            Console.WriteLine("6. Mostrar todos los libros ordenados por año");
            Console.WriteLine("7. Aplicar descuento a un libro");
            Console.WriteLine("8. Verificar si un libro es reciente");
            Console.WriteLine("9. Mostrar descripción detallada de un libro");
            Console.WriteLine("10. Salir");
            Console.Write("Seleccione una opción: ");

            // Leo la opción ingresada por el usuario y valida que sea un número
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Por favor, ingrese un número válido.");
                Console.ReadKey();
                continue;
            }

            try
            {
                // Ejecuto la acción correspondiente según la opción seleccionada
                switch (choice)
                {
                    case 1:
                        _library.AddBookFromUserInput(); // Llamo al método para agregar un libro
                        break;
                    case 2:
                        _library.RemoveBookFromUserInput(); // Llamo al método para eliminar un libro
                        break;
                    case 3:
                        _library.SearchBooksByAuthorFromUserInput(); // Llamo al método para buscar libros por autor
                        break;
                    case 4:
                        _library.SearchBooksByGenreFromUserInput(); // Llamo al método para buscar libros por género
                        break;
                    case 5:
                        _library.SearchBooksByYearRangeFromUserInput(); // Llamo al método para buscar libros por rango de años
                        break;
                    case 6:
                        _library.ShowAllBooksSortedByYear(); // Llamo al método para mostrar todos los libros ordenados por año
                        break;
                    case 7:
                        _library.ApplyDiscountToBookFromUserInput(); // Llamo al método para aplicar un descuento a un libro
                        break;
                    case 8:
                        _library.CheckIfBookIsRecentFromUserInput(); // Llamo al método para verificar si un libro es reciente
                        break;
                    case 9:
                        _library.ShowDetailedDescriptionFromUserInput(); // Llamo al método para mostrar una descripción detallada de un libro
                        break;
                    case 10:
                        exit = true; // Establezco la bandera exit a true para salir del bucle
                        Console.WriteLine("Gracias por usar el Sistema de Gestión de Biblioteca. ¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, intente de nuevo."); // Mensaje para opciones no válidas
                        break;
                }
            }
            catch (Exception ex)
            {
                // Capturo y muestra cualquier excepción que ocurra durante la ejecución
                Console.WriteLine($"Error: {ex.Message}");
            }

            if (!exit)
            {
                // Solicito al usuario que presione una tecla para continuar si no se ha salido
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
