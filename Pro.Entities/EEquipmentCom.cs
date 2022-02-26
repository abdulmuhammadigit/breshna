using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pro.Entities
{
  public  class EEquipmentCom
    {
        [Key]
        public int EEquipmentComID { get; set; }

        public string Name { get; set; }
        public int Count { get; set; }

        public string AstahlakYear { get; set; }


        public string Info { get; set; }
        [ForeignKey("OwnerId")]
        public Owner Owner { get; set; }
        public int OwnerId { get; set; }
    }
}
