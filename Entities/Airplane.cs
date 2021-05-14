using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Airplane : AbstractEntity
    {
        [Required]
        public string Company {get; set; }
        [Required]
        public string Model {get; set; }
        [Required]
        public int Seats {get; set; }
        [Required]
        public int DefaultPrice {get; set; }
        
        public virtual List<Flight> Flights { get; set; }
    }
}
