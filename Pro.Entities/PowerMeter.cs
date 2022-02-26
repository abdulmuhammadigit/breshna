using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pro.Entities
{
   public class PowerMeter
    {
        [Key]
        public int PowerMeterId { get; set; }


        public int IDMeter { get; set; }


        public string DigitalOrAnalog { get; set; }

       

        [ForeignKey("OwnerId")]
        public Owner Owner { get; set; }
        public int OwnerId { get; set; }
    }
}
