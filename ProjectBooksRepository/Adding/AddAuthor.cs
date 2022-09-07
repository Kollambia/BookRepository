using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectBooksRepository.Entities;

namespace ProjectBooksRepository.Adding
{
    internal static class AddNewAuthor
    {
        public static void AuthorGenerator(string name, string surname, string gender, DateTime birthDay)
        {
            using (BookRepositoryDbContext br = new BookRepositoryDbContext())
            {
                Authors author1 = new Authors()
                {
                    FirstName = name,
                    LastName = surname,
                    Gender = gender,
                    AuthorsBirthDay = birthDay
                };
                br.Authors.Add(author1);
                br.SaveChanges();
            }
        }
    }
}
