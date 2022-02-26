using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pro.Entities
{
  public  class OwnerLanguage
    {
        [Key]
        public int LanguageId { get; set; }
        public string Name { get; set; }

        [ForeignKey("OwnerId")]
        public Owner Owner { get; set; }
        public int OwnerId { get; set; }
    }
}
