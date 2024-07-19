using LibraryManagementSystem.models;
class Program
{
    static void Main(string[] args)
    {
        // Creo una instancia de la clase Library
        Library library = new Library();

        // Creo una instancia de la clase UserInterface, pasando la instancia de Library como argumento
        UserInterface ui = new UserInterface(library);

        // Agrego 3 libros por defecto
        library.AddBook(new Book("To Kill a Mockingbird", new DateOnly(1960, 7, 11), "Harper Lee", "978-0446310789", "Fiction", 50000m));
        library.AddBook(new Book("1984", new DateOnly(1949, 6, 8), "George Orwell", "978-0451524935", "Fiction", 45000m));
        library.AddBook(new Book("The Great Gatsby", new DateOnly(1925, 4, 10), "F. Scott Fitzgerald", "978-0743273565", "Fiction", 40000m));

        ui.Run();
    }
}