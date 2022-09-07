using ProjectBooksRepository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBooksRepository.Removers
{
    internal class BooksRemover
    {
        public bool Remover(string name)
        {
            using (BookRepositoryDbContext br = new BookRepositoryDbContext())
            {
                var books = (from b in br.Books
                             where b.BookName == name
                             select b).FirstOrDefault();
                br.Books.Remove(books);
                br.SaveChanges();

                if (books != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
