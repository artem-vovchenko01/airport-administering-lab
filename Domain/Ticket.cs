using System;
using System.Collections.Generic;

namespace Domain
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public decimal Price { get; set; }
        public Guid FlightId { get; set;}
        public Guid PassengerId { get; set; }
        
        // public IList<int> SeatsOccupiedList {get {return _seatsOccupiedList; } internal set {
        // public int SeatsOccupied {get; set; }
    }
}
