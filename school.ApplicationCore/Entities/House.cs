using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace school.ApplicationCore.Entities
{
    public class House
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string HouseName { get; set; }
    }

    public class DataHouse
    {
        List<House> _listHouses = new List<House>
            {
                new House() { Id = 1, HouseName = "Gryffindor" },
                new House() { Id = 2, HouseName = "Hufflepuff" },
                new House() { Id = 3, HouseName = "Ravenclaw" },
                new House() { Id = 4, HouseName = "Slytherin" }
            };
    }
}
