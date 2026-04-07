using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper1.Models;

namespace Dapper1.Data
{
    public class BookRepository
    {
        private readonly string connectionString = "Server=Thiru\\SQLEXPRESS;Database=Dapper1;Trusted_Connection=True;TrustServerCertificate=True;";

        private IDbConnection Connection => new SqlConnection(connectionString);

        public void AddBook(Book book)
        {
            using var db = Connection;

            string query = @"INSERT INTO Book 
                             (Title, Price, Author, Publisher, Language, PublicationDate)
                             VALUES 
                             (@Title, @Price, @Author, @Publisher, @Language, @PublicationDate)";

            db.Execute(query, book);
        }

        public void EditBook(Book book)
        {
            using var db = Connection;

            string query = @"UPDATE Book 
                             SET Price = @Price,
                                 Author = @Author,
                                 Publisher = @Publisher,
                                 Language = @Language
                             WHERE BookId = @BookId";

            db.Execute(query, book);
        }

        public void DeleteBook(int id)
        {
            using var db = Connection;

            string query = "DELETE FROM Book WHERE BookId = @id";

            db.Execute(query, new { id });
        }

        public Book? GetBookById(int id)
        {
            using var db = Connection;

            return db.QueryFirstOrDefault<Book>(
                "SELECT * FROM Book WHERE BookId = @id", new { id });
        }

        public Book? GetBookByName(string name)
        {
            using var db = Connection;

            return db.QueryFirstOrDefault<Book>(
                "SELECT * FROM Book WHERE Title = @name", new { name });
        }

        public List<Book> GetAllBooks()
        {
            using var db = Connection;

            return db.Query<Book>("SELECT * FROM Book").ToList();
        }

        public List<Book> GetBooksByAuthor(string author)
        {
            using var db = Connection;

            return db.Query<Book>(
                "SELECT * FROM Book WHERE Author = @author", new { author }).ToList();
        }
    }
}