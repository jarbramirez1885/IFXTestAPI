using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace school.api.Entities
{
    public class House
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string HouseName { get; set; }
    }
}
