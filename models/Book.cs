using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.models
{
    // Defino la clase Book que hereda de la clase Publication
    public class Book : Publication
    {
        // Propiedades para almacenar información del libro
        public string? Author { get; set; }// Autor del libro
        public string? ISBN { get; set; }// ISBN del libro
        public string? Genre { get; set; }// Género del libro
        public decimal Price { get; set; }// Precio del libro

        // Constructor que inicializa las propiedades del libro 
        public Book(string title, DateOnly publicationYear, string author, string isbn, string genre, decimal price) : base(title, publicationYear)// Llama al constructor base de Publication con title y publicationYear
        {
            Author = author;
            ISBN = isbn;
            Genre = genre;
            Price = price;
        }
    }
}