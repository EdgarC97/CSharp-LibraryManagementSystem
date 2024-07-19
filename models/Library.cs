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
            Console.WriteLine("| Título                 | Autor                 | ISBN           | Género    | Año  | Precio          |");
            Console.WriteLine("|------------------------|-----------------------|----------------|-----------|------|-----------------|");

            // Itera sobre cada libro en la colección y lo imprime en una fila de la tabla
            foreach (var book in books)
            {
                Console.WriteLine($"| {book.Title,-22} | {book.Author,-21} | {book.ISBN,-13} | {book.Genre,-9} | {book.PublicationYear.Year,-4} | {book.Price,-10:C}     |");
            }
        }
    }
}