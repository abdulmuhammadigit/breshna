using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pro.Entities
{
  public  class RentEEquipmentH
    {
        [Key]
        public int EEquipmentHID { get; set; }

        public string Name { get; set; }
        public int Count { get; set; }

        public string AstahlakYear { get; set; }


        [ForeignKey("RentId")]
        public Rent Rent { get; set; }
        public int RentId { get; set; }

    }
}
