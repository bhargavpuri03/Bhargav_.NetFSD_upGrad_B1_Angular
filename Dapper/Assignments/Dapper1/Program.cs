using System;
using Dapper1.Data;
using Dapper1.Models;

class Program
{
    static void Main()
    {
        var repo = new BookRepository();

        while (true)
        {
            Console.WriteLine("\n1.Add Book");
            Console.WriteLine("2.Edit Book");
            Console.WriteLine("3.Delete Book");
            Console.WriteLine("4.Get Book by ID");
            Console.WriteLine("5.Get Book by Name");
            Console.WriteLine("6.Get All Books");
            Console.WriteLine("7.Get Books by Author");
            Console.WriteLine("8.Exit");

            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine() ?? string.Empty);

            switch (choice)
            {
                case 1:
                    var book = new Book();

                    Console.Write("Title: ");
                    book.Title = Console.ReadLine();

                    Console.Write("Price: ");
                    book.Price = decimal.Parse(Console.ReadLine() ?? string.Empty);

                    Console.Write("Author: ");
                    book.Author = Console.ReadLine();

                    Console.Write("Publisher: ");
                    book.Publisher = Console.ReadLine();

                    Console.Write("Language: ");
                    book.Language = Console.ReadLine();

                    book.PublicationDate = DateTime.Now;

                    repo.AddBook(book);
                    Console.WriteLine("Book Added!");
                    break;

                case 2:
                    var edit = new Book();

                    Console.Write("BookId: ");
                    edit.BookId = int.Parse(Console.ReadLine() ?? string.Empty);

                    Console.Write("New Price: ");
                    edit.Price = decimal.Parse(Console.ReadLine() ?? string.Empty);

                    Console.Write("New Author: ");
                    edit.Author = Console.ReadLine();

                    Console.Write("New Publisher: ");
                    edit.Publisher = Console.ReadLine();

                    Console.Write("New Language: ");
                    edit.Language = Console.ReadLine();

                    repo.EditBook(edit);
                    Console.WriteLine("Book Updated!");
                    break;

                case 3:
                    Console.Write("Enter BookId: ");
                    int deleteId = int.Parse(Console.ReadLine() ?? string.Empty);

                    repo.DeleteBook(deleteId);
                    Console.WriteLine("Book Deleted!");
                    break;

                case 4:
                    Console.Write("Enter BookId: ");
                    int id = int.Parse(Console.ReadLine() ?? string.Empty);

                    var b1 = repo.GetBookById(id);

                    if (b1 != null)
                        Console.WriteLine($"{b1.BookId} {b1.Title} {b1.Author} {b1.Price} {b1.PublicationDate}");
                    else
                        Console.WriteLine("Book not found");
                    break;

                case 5:
                    Console.Write("Enter Book Name: ");
                    string name = Console.ReadLine() ?? string.Empty;

                    var b2 = repo.GetBookByName(name);

                    if (b2 != null)
                        Console.WriteLine($"{b2.BookId} {b2.Title} {b2.Author} {b2.Price} {b2.PublicationDate}");
                    else
                        Console.WriteLine("Book not found");
                    break;

                case 6:
                    var allBooks = repo.GetAllBooks();

                    foreach (var b in allBooks)
                        Console.WriteLine($"{b.BookId} {b.Title} {b.Author} {b.Price} {b.PublicationDate}");
                    break;

                case 7:
                    Console.Write("Enter Author: ");
                    string author = Console.ReadLine() ?? string.Empty;

                    var booksByAuthor = repo.GetBooksByAuthor(author);

                    foreach (var b in booksByAuthor)
                        Console.WriteLine($"{b.BookId} {b.Title} {b.Author} {b.PublicationDate}");
                    break;

                case 8:
                    return;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}