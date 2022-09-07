using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectBooksRepository.Entities;

namespace ProjectBooksRepository.DataOutput
{
    internal class OutputAllAuthors
    {
        public static void Output()
        {
            using (BookRepositoryDbContext db = new BookRepositoryDbContext())
            {
                var authors = db.Authors.ToList();
                foreach (Authors author in authors)
                {
                    Console.WriteLine($"Id {author.Id}, Name: {author.FirstName}, Surname: {author.LastName}, Birth day: {author.AuthorsBirthDay}, Gengder: {author.Gender}");
                }
            }

        }
    }
}
