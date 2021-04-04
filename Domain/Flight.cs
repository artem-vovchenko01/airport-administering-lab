using System;

namespace Domain
{
    public class Flight
    {
        public Guid Id { get; set; }
        public DateTime TimeDepart { get; set; }
        public DateTime TimeArrive { get; set; }
        public DateTime StopBooking { get; set; }
        public int MinDelayed { get; set; }
        
        public Guid RouteId { get; set; }

        // public int SeatsCapacity { get; set; }
        // public IRoute<int> Route {get; set; }
    }
}