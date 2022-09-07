using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBooksRepository.Entities
{
    public class Books
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string BookName { get; set; }

        [Required]
        public int PagesNumber { get; set; }

        [MaxLength(10000)]
        public string Description { get; set; }

        [Required]
        public sbyte СriticalAppraisal { get; set; }

        [MaxLength(250)]
        [Required]
        public string Genre { get; set; }

        public List<Authors> Authors { get; set; } = new();

    }
}
