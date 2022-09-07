using Microsoft.EntityFrameworkCore;
using ProjectBooksRepository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBooksRepository.Changes
{
    internal static class ChangesForBooks
    {
        public static void Changes(int id)
        {
            using (BookRepositoryDbContext db = new BookRepositoryDbContext())
            {
                try
                {
                    var books = db.Books.Where(b => b.Id == id).FirstOrDefault();
                    Console.WriteLine("Enter what you want to change");
                    Console.WriteLine("You can change: book name, pages number, description, critical appraisal");
                    string answer = Console.ReadLine().ToLower().Trim();
                    switch (answer)
                    {
                        case "book name":
                            string name = Console.ReadLine();
                            books.BookName = name;
                            db.SaveChanges();
                            break;

                        case "pages number":
                            int pages = int.Parse(Console.ReadLine());
                            books.PagesNumber = pages;
                            db.SaveChanges();
                            break;

                        case "description":
                            string description = Console.ReadLine();
                            books.Description = description;
                            db.SaveChanges();
                            break;

                        case "critical appraisal":
                            sbyte evaluation = sbyte.Parse(Console.ReadLine());
                            books.СriticalAppraisal = evaluation;
                            db.SaveChanges();
                            break;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Try again");
                    Changes(id);
                }
                
            }
        }
       
    }
}
