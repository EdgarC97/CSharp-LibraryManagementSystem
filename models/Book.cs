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
        public void ApplyDiscount(decimal percentageDiscount)// Método para aplicar un descuento al precio del libro
        {
            decimal discount = Price * percentageDiscount / 100;// Calculo el monto del descuento
            Price -= discount;// Resto el descuento al precio original
        }

        public bool IsRecent()// Método para determinar si el libro se publicó en los últimos 5 años
        {
            // Comparo el año de publicación con la fecha actual menos 5 años
            return PublicationYear >= DateOnly.FromDateTime(DateTime.Now.AddYears(-5));
        }
        public void GetDetailedDescription()// Método para imprimir una descripción detallada del libro en la consola
        {
            Console.WriteLine($"Título: {Title}, Autor: {Author}, ISBN: {ISBN}, Género: {Genre}, Año de Publicación: {PublicationYear.Year}, Precio: {Price:C}");
        }

        public override string ToString()// Sobrescribo el método ToString() para devolver una cadena que representa el libro
        {
            return $"Título: {Title}, Autor: {Author}, ISBN: {ISBN}, Género: {Genre}, Año de Publicación: {PublicationYear.Year}, Precio: {Price:C}";
        }
    }
}