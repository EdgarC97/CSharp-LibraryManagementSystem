using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.models
{
    // Clase estática Validator que contiene métodos para validar datos de libros y entradas del usuario
    public static class Validator
    {
        // Método para validar un objeto Book
        public static void ValidateBook(Book book)
        {
            // Verifica si el objeto Book es nulo y lanza una excepción si es así
            if (book == null)
                throw new ArgumentNullException("El libro no puede ser nulo.");

            // Verifica si el título del libro está vacío o es nulo
            if (string.IsNullOrWhiteSpace(book.Title))
                throw new ArgumentException("El título del libro no puede estar vacío.");
            // Valida el título utilizando el método ValidateSearchTerm
            ValidateSearchTerm(book.Title, "título");

            // Verifica si el autor del libro está vacío o es nulo
            if (string.IsNullOrWhiteSpace(book.Author))
                throw new ArgumentException("El autor del libro no puede estar vacío.");
            // Valida el autor utilizando el método ValidateSearchTerm
            ValidateSearchTerm(book.Author, "autor");

            // Valida el ISBN del libro; si el ISBN es nulo, lanza una excepción
            ValidateISBN(book.ISBN ?? throw new ArgumentNullException("El ISBN no puede ser nulo."));

            // Verifica si el género del libro está vacío o es nulo
            if (string.IsNullOrWhiteSpace(book.Genre))
                throw new ArgumentException("El género del libro no puede estar vacío.");
            // Valida el género utilizando el método ValidateSearchTerm
            ValidateSearchTerm(book.Genre, "género");

            // Valida el año de publicación utilizando el método ValidateYear
            ValidateYear(book.PublicationYear.Year);
            // Valida el precio del libro utilizando el método ValidatePrice
            ValidatePrice(book.Price);
        }

        // Método para validar que un ISBN no esté vacío
        public static void ValidateISBN(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("El ISBN no puede estar vacío.");
        }

        // Método para validar que el año no sea negativo
        public static void ValidateYear(int year)
        {
            if (year < 0)
                throw new ArgumentException("El año de publicación no puede ser negativo.");
        }

        // Método para validar que el precio no sea negativo
        public static void ValidatePrice(decimal price)
        {
            if (price < 0)
                throw new ArgumentException("El precio no puede ser negativo.");
        }

        // Método para validar que el año de inicio sea menor o igual al año final
        public static void ValidateYearRange(int startYear, int endYear)
        {
            if (startYear > endYear)
                throw new ArgumentException("El año de inicio debe ser menor o igual al año final.");
        }

        // Método para validar que un término de búsqueda no esté vacío
        public static void ValidateSearchTerm(string term, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(term))
                throw new ArgumentException($"El {fieldName} de búsqueda no puede estar vacío.");
        }

        // Método para obtener y validar el título desde la entrada del usuario
        public static string GetValidTitleFromUserInput()
        {
            Console.Write("Título: ");
            string title = Console.ReadLine() ?? "";
            // Valida el título utilizando el método ValidateSearchTerm
            ValidateSearchTerm(title, "título");
            return title;
        }

        // Método para obtener y validar el autor desde la entrada del usuario
        public static string GetValidAuthorFromUserInput()
        {
            Console.Write("Autor: ");
            string author = Console.ReadLine() ?? "";
            // Valida el autor utilizando el método ValidateSearchTerm
            ValidateSearchTerm(author, "autor");
            return author;
        }

        // Método para obtener y validar el ISBN desde la entrada del usuario
        public static string GetValidISBNFromUserInput()
        {
            Console.Write("ISBN: ");
            string isbn = Console.ReadLine() ?? "";
            // Valida el ISBN utilizando el método ValidateISBN
            ValidateISBN(isbn);
            return isbn;
        }

        // Método para obtener y validar el género desde la entrada del usuario
        public static string GetValidGenreFromUserInput()
        {
            Console.Write("Género: ");
            string genre = Console.ReadLine() ?? "";
            // Valida el género utilizando el método ValidateSearchTerm
            ValidateSearchTerm(genre, "género");
            return genre;
        }

        // Método para obtener y validar el año de publicación desde la entrada del usuario
        public static int GetValidYearFromUserInput()
        {
            Console.Write("Año de publicación (YYYY): ");
            // Intenta convertir la entrada a un número entero
            if (!int.TryParse(Console.ReadLine(), out int year))
            {
                throw new ArgumentException("Año inválido.");
            }
            // Valida el año utilizando el método ValidateYear
            ValidateYear(year);
            return year;
        }

        // Método para obtener y validar el precio desde la entrada del usuario
        public static decimal GetValidPriceFromUserInput()
        {
            Console.Write("Precio: ");
            // Intenta convertir la entrada a un número decimal
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                throw new ArgumentException("Precio inválido.");
            }
            // Valida el precio utilizando el método ValidatePrice
            ValidatePrice(price);
            return price;
        }
    }
}