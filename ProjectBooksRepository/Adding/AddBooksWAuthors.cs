using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectBooksRepository.Entities;

namespace ProjectBooksRepository.Adding
{
    internal static class AddBooksWAuthors
    {
        public static void BookGeneratorWithAuthor(string name, int pages, string description, sbyte evaluation, string genre,
                                                    string firstName, string lastname, DateTime birthDate, string gender)
        {
            using (BookRepositoryDbContext br = new BookRepositoryDbContext())
            {

                Books book1 = new Books
                {
                    BookName = name,
                    PagesNumber = pages,
                    Description = description,
                    СriticalAppraisal = evaluation,
                    Genre = genre,
                };
                br.Books.Add(book1);

                Authors author1 = new Authors
                {
                    FirstName = firstName,
                    LastName = lastname,
                    AuthorsBirthDay = birthDate,
                    Gender = gender
                };
                br.Authors.Add(author1);

                book1.Authors.Add(author1);

                br.SaveChanges();
            }
        }
        public static void BookGeneretorWithoutAuthor(string name, int pages, string description, sbyte evaluation, string genre)
        {
            using (BookRepositoryDbContext br = new BookRepositoryDbContext())
            {
                Books book1 = new Books()
                {
                    BookName = name,
                    PagesNumber = pages,
                    Description = description,
                    СriticalAppraisal = evaluation,
                    Genre = genre
                };
                br.Books.Add(book1);

                br.SaveChanges();
            }
        }
    }
}
