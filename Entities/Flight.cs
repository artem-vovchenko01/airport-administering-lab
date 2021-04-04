using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Flight : AbstractEntity
    {
        [Required]
        public DateTime TimeDepart { get; set; }
        [Required]
        public DateTime TimeArrive { get; set; }
        [Required]
        public DateTime StopBooking { get; set; }
        [Required]
        public int MinDelayed { get; set; }
        [Required]
        public Guid RouteId { get; set; }

        public virtual Route Route { get; set; }
        public virtual List<Ticket> Tickets { get; set; }
        // public int SeatsCapacity { get; set; }
        // public IRoute<int> Route {get; set; }
    }
}