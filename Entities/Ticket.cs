using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Ticket : AbstractEntity
    {
        [Required]
        public int Adults { get; set; }
        [Required]
        public int Children { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public Guid FlightId { get; set;}
        [Required]
        public Guid PassengerId { get; set; }
        
        public virtual Passenger Passenger { get; set; }
        public virtual Flight Flight { get; set; }
        public virtual List<Seat> SeatsOccupied { get; set; }
    }
}
