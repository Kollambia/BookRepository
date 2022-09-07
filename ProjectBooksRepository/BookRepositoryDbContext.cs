using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProjectBooksRepository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBooksRepository
{
    internal class BookRepositoryDbContext : DbContext
    {
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Books> Books { get; set; }

        public BookRepositoryDbContext()
        {
            try
            {
                Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseSqlServer("Server =.; Database = BooksRepository; Trusted_Connection = True; TrustServerCertificate = true;");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
