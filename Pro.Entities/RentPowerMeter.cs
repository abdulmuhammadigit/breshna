using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pro.Entities
{
   public class RentPowerMeter
    {
        [Key]
        public int PowerMeterId { get; set; }


        public int IDMeter { get; set; }


        public string DigitalOrAnalog { get; set; }



        [ForeignKey("RentId")]
        public Rent Rent { get; set; }
        public int RentId { get; set; }
    }
}

