using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjectBooksRepository.Changes
{
    internal class ChangesForAuthors
    {
        public static void Changes(int id)
        {
            using (var br = new BookRepositoryDbContext())
            {
                try
                {
                    var author = br.Authors.Where(a => a.Id == id).FirstOrDefault();
                    Console.WriteLine("Enter what you want to change");
                    Console.WriteLine("You can change: name, last name, gender, birth day");
                    string answer = Console.ReadLine().ToLower().Trim();
                    switch (answer)
                    {
                        case "name":
                            string name = Console.ReadLine();
                            author.FirstName = name;
                            br.SaveChanges();
                            break;
                        case "last name":
                            string surname = Console.ReadLine();
                            author.LastName = surname;
                            br.SaveChanges();
                            break;
                        case "gender":
                            string gender = Console.ReadLine();
                            author.LastName = gender;
                            br.SaveChanges();
                            break;
                        case "birth day":
                            DateTime birthDay;
                            DateTime.TryParse(Console.ReadLine(), out birthDay);
                            author.AuthorsBirthDay = birthDay;
                            br.SaveChanges();
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
