using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBooksRepository.Removers
{
    internal class AuthorRemover
    {
        public bool Remover(string name)
        {
            using (BookRepositoryDbContext br = new BookRepositoryDbContext())
            {
                var author = (from a in br.Authors
                              where a.FirstName == name
                              select a).FirstOrDefault();
                br.Authors.Remove(author);
                br.SaveChanges();

                if (author != null)
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
