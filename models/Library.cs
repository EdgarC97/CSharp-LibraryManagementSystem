using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.models
{
    public class Library
    {
        private List<Book> books = new List<Book>();

        //Metodo para Agregar un libro a la colección de libros
        public void AddBook(Book book)
        {
            // Validar el objeto Book
            Validator.ValidateBook(book);

            // Comprobar si ya existe un libro con el mismo nombre
            if (books.Any(b => b.Title == book.Title))
                throw new ArgumentException("Ya existe un libro con este nombre.", nameof(book));

            // Agregar el libro a la colección
            books.Add(book);
        }

        // Método para agregar un libro desde la entrada del usuario (1)
        public void AddBookFromUserInput()
        {
            Console.WriteLine("\n=== Agregar Libro ===");

            // Usamos el Validator para obtener y validar todos los campos necesarios
            string title = Validator.GetValidTitleFromUserInput();
            string author = Validator.GetValidAuthorFromUserInput();
            string isbn = Validator.GetValidISBNFromUserInput();
            string genre = Validator.GetValidGenreFromUserInput();
            int year = Validator.GetValidYearFromUserInput();
            decimal price = Validator.GetValidPriceFromUserInput();

            // Creamos un nuevo libro con los datos validados
            Book newBook = new Book(title, new DateOnly(year, 1, 1), author, isbn, genre, price);

            // Validamos el nuevo libro utilizando el método ValidateBook
            Validator.ValidateBook(newBook);

            // Agregamos el libro a la lista si pasa las validaciones
            AddBook(newBook);
            Console.WriteLine("Libro agregado exitosamente.");
        }

        // Método para eliminar un libro por su título (2)
        public void RemoveBookFromUserInput()
        {
            Console.WriteLine("\n=== Eliminar Libro ===");
            Console.Write("Ingrese el título del libro a eliminar: ");
            string title = Console.ReadLine() ?? "";// Lee la entrada del usuario y asigna una cadena vacía si la entrada es nula

            // Buscamos el libro por título en la lista utilizando LINQ    
            var bookToRemove = books.FirstOrDefault(b => (b.Title ?? "").Equals(title, StringComparison.OrdinalIgnoreCase));

            // Verifica si se encontró un libro con el título proporcionado
            if (bookToRemove == null)
            {
                Console.WriteLine("No se encontró un libro con ese título.");
                return;
            }

            // Mostramos los detalles del libro y pedimos confirmación
            Console.WriteLine("Libro encontrado:");
            Console.WriteLine(bookToRemove.ToString());
            Console.Write("¿Está seguro de que desea eliminar este libro? (s/n): ");
            string confirmation = Console.ReadLine()?.ToLower() ?? "";

            if (confirmation == "s")
            {
                books.Remove(bookToRemove);
                Console.WriteLine("Libro eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("Eliminación cancelada.");
            }
        }

        // Método para buscar libros por autor (3)
        public void SearchBooksByAuthorFromUserInput()
        {
            Console.WriteLine("\n=== Buscar Libros por Autor ===");
            Console.Write("Ingrese el nombre del autor: ");
            string author = Console.ReadLine() ?? "";// Lee la entrada del usuario y asigna una cadena vacía si la entrada es nula
            // Busca los libros en la colección cuyo autor coincide con el nombre ingresado
            var foundBooks = books.Where(b => (b.Author ?? "").Equals(author, StringComparison.OrdinalIgnoreCase));
            PrintBooksAsTable(foundBooks);
        }

        // Método para buscar libros por género (4)
        public void SearchBooksByGenreFromUserInput()
        {
            Console.WriteLine("\n=== Buscar Libros por Género ===");
            Console.Write("Ingrese el género: ");
            string genre = Console.ReadLine() ?? "";// Lee la entrada del usuario y asigna una cadena vacía si la entrada es nula
                                                    // Busca los libros en la colección cuyo género coincide con el género ingresad
            var foundBooks = books.Where(b => (b.Genre ?? "").Equals(genre, StringComparison.OrdinalIgnoreCase));
            PrintBooksAsTable(foundBooks);
        }

        // Método para buscar libros por rango de años (5)
        public void SearchBooksByYearRangeFromUserInput()
        {
            Console.WriteLine("\n=== Buscar Libros por Rango de Años ===");
            Console.Write("Año de inicio: ");
            // Intenta convertir la entrada del usuario en un número entero
            // Si la conversión falla, se lanza una excepción con un mensaje de error
            if (!int.TryParse(Console.ReadLine(), out int startYear))
            {
                throw new ArgumentException("Año de inicio inválido.");
            }
            Console.Write("Año de fin: ");

            // Intenta convertir la entrada del usuario en un número entero
            // Si la conversión falla, se lanza una excepción con un mensaje de error
            if (!int.TryParse(Console.ReadLine(), out int endYear))
            {
                throw new ArgumentException("Año de fin inválido.");
            }

            // Busca los libros en la colección cuyo año de publicación esté dentro del rango especificado
            // Utiliza la propiedad 'PublicationYear.Year' para comparar con los años de inicio y fin
            var foundBooks = books.Where(b => b.PublicationYear.Year >= startYear && b.PublicationYear.Year <= endYear);
            PrintBooksAsTable(foundBooks);
        }

        // Método para mostrar todos los libros ordenados por año (6)
        public void ShowAllBooksSortedByYear()
        {
            Console.WriteLine("\n=== Todos los Libros Ordenados por Año ===");

            // Ordena la colección de libros por el año de publicación en orden ascendente
            var sortedBooks = books.OrderBy(b => b.PublicationYear);

            PrintBooksAsTable(sortedBooks);
        }

        // Método para aplicar descuento a un libro (7)
        public void ApplyDiscountToBookFromUserInput()
        {
            Console.WriteLine("\n=== Aplicar Descuento a un Libro ===");
            Console.Write("Ingrese el título del libro: ");
            string title = Console.ReadLine() ?? "";

            // Busca el libro con el título proporcionado
            var book = books.FirstOrDefault(b => (b.Title ?? "").Equals(title, StringComparison.OrdinalIgnoreCase));

            // Verifica si se encontró el libro
            if (book == null)
            {
                Console.WriteLine("No se encontró un libro con ese título.");
                return;
            }

            Console.Write("Ingrese el porcentaje de descuento (0-100): ");
            // Intenta convertir la entrada del usuario a un valor decimal y verifica que esté en el rango permitido
            if (!decimal.TryParse(Console.ReadLine(), out decimal discount) || discount < 0 || discount > 100)
            {
                Console.WriteLine("Porcentaje de descuento inválido.");
                return;
            }

            // Aplica el descuento al libro encontrado
            book.ApplyDiscount(discount);
            Console.WriteLine($"Descuento aplicado. Nuevo precio: {book.Price:C}");
        }

        // Método para verificar si un libro es reciente (8)
        public void CheckIfBookIsRecentFromUserInput()
        {
            Console.WriteLine("\n=== Verificar si un Libro es Reciente ===");
            Console.Write("Ingrese el título del libro: ");
            string title = Console.ReadLine() ?? "";

            // Busca el primer libro en la colección que coincida con el título proporcionado
            // Utiliza FirstOrDefault para obtener el primer resultado que coincide o null si no se encuentra ninguno
            var book = books.FirstOrDefault(b => (b.Title ?? "").Equals(title, StringComparison.OrdinalIgnoreCase));

            // Verifica si se encontró el libro
            if (book == null)
            {
                Console.WriteLine("No se encontró un libro con ese título.");
                return;
            }

            // Verifica si el libro es reciente utilizando el método IsRecent
            bool isRecent = book.IsRecent();
            Console.WriteLine(isRecent
                ? "El libro es reciente (publicado en los últimos 5 años)."
                : "El libro no es reciente (publicado hace más de 5 años).");
        }

        // Método para mostrar la descripción detallada de un libro (9)
        public void ShowDetailedDescriptionFromUserInput()
        {
            Console.WriteLine("\n=== Mostrar Descripción Detallada de un Libro ===");
            Console.Write("Ingrese el título del libro: ");
            string title = Console.ReadLine() ?? "";

            // Busca el primer libro en la colección que coincida con el título proporcionado
            // Utiliza FirstOrDefault para obtener el primer resultado que coincide o null si no se encuentra ninguno
            var book = books.FirstOrDefault(b => (b.Title ?? "").Equals(title, StringComparison.OrdinalIgnoreCase));

            // Verifica si se encontró el libro
            if (book == null)
            {
                Console.WriteLine("No se encontró un libro con ese título.");
                return;
            }
            // Llama al método GetDetailedDescription del libro para mostrar la descripción detallada
            book.GetDetailedDescription();
        }

        // Método para imprimir los libros en formato de tabla 
        private void PrintBooksAsTable(IEnumerable<Book> books)
        {
            // Verifica si la colección de libros está vacía
            if (!books.Any())
            {
                Console.WriteLine("No se encontraron libros.");
                return;
            }
            // Imprime el encabezado de la tabla con las columnas para Título, Autor, ISBN, Género, Año y Precio
            Console.WriteLine("| Título                 | Autor                 | ISBN           | Género    | Año  | Precio         |");
            Console.WriteLine("|------------------------|-----------------------|----------------|-----------|------|----------------|");

            // Itera sobre cada libro en la colección y lo imprime en una fila de la tabla
            foreach (var book in books)
            {
                Console.WriteLine($"| {book.Title,-22} | {book.Author,-21} | {book.ISBN,-13} | {book.Genre,-9} | {book.PublicationYear.Year,-4} | {book.Price,-10:C}     |");
            }
        }
    }
}