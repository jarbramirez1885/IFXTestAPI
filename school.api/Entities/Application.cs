using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace school.api.Entities
{
    public class Application
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Required]
        [Range(1, 10000000000, ErrorMessage = "Rating must between 1 to 10")]
        public int Identification { get; set; }
        [Required]
        [Range(1, 99, ErrorMessage = "Rating must between 1 to 2")]
        public int Age { get; set; }
        [Required]
        public string House { get; set; }

    }
}
