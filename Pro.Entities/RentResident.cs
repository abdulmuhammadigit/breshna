using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pro.Entities
{
    public class RentResident
    {
        [Key]
        public int ResidentId { get; set; }
        public string Gender { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Job { get; set; }

        public double Income { get; set; }


        [ForeignKey("RentId")]
        public Rent Rent { get; set; }
        public int RentId { get; set; }
    }
}