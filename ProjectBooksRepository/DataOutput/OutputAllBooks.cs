using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectBooksRepository.Entities;

namespace ProjectBooksRepository.DataOutput
{
    internal class OutputAllBooks
    {
        public static void Output()
        {
            using (BookRepositoryDbContext db = new BookRepositoryDbContext())
            {
                var books = db.Books.ToList();
                foreach (Books book in books)
                {
                    Console.WriteLine($"Id: {book.Id}, Name: {book.BookName}, number of pages: {book.PagesNumber}, Description: {book.Description}, Genre: {book.Genre}");
                }
            }
        }
    }
}
