using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBooksRepository.Entities
{
    public class Authors
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string? FirstName { get; set; }

        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public DateTime AuthorsBirthDay { get; set; }

        public List<Books> Books { get; set; } = new();
    }
}
