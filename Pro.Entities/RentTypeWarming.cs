using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pro.Entities
{
  public  class RentTypeWarming
    {
        [Key]
        public int TypeWarmingId { get; set; }

        public string Name { get; set; }

        [ForeignKey("RentId")]
        public Rent Rent { get; set; }
        public int RentId { get; set; }
    }
}
