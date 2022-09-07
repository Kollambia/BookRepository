using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectBooksRepository.Entities;

namespace ProjectBooksRepository.Searching
{
    internal class BooksSearcher
    {
        public bool Searcher(string name)
        {
            using (BookRepositoryDbContext br = new BookRepositoryDbContext())
            {
                var books = br.Books.Where(b => b.BookName == name);
                foreach (Books book in books)
                {
                    Console.WriteLine($"{book.BookName}, {book.PagesNumber}, {book.СriticalAppraisal}, {book.Genre}");
                    return true;
                }
                return false;
            }
        }
    }
}
