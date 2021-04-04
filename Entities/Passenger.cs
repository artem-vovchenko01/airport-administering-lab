using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Passenger : AbstractEntity
    {
        [Required]
        public string Name {get; set;}
        [Required]
        public string Surname {get; set; }
        [Required]
        public long Passport {get; set; }
        [Required]
        public int Age {get; set; }
        
        public virtual List<Ticket> Tickets { get; set; }
    }
}
