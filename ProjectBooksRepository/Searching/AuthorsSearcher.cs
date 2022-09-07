using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectBooksRepository.Entities;

namespace ProjectBooksRepository.Searching
{
    internal class AuthorsSearcher
    {
        public bool Searcher(string name)
        {
            using (BookRepositoryDbContext br = new BookRepositoryDbContext())
            {
                var authors = br.Authors.Where(a => a.FirstName == name);
                foreach (Authors author in authors)
                {
                    Console.WriteLine($"{author.FirstName}, {author.LastName}, {author.AuthorsBirthDay}, {author.Gender}");
                    return true;
                }
            }
            return false;
        }
    }
}
