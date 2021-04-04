using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Seat : AbstractEntity
    {
        [Required]
        public int SeatNumber { get; set; }
        [Required]
        public Guid TicketId { get; set; }
        
        public virtual Ticket Ticket { get; set; }
    }
}
