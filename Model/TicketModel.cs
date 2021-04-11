using System;
using System.Collections.Generic;

namespace Model
{
    public class TicketModel : AbstractModel
    {
        private int _adults;
        private int _children;
        private decimal _price;

        public int Adults
        {
            get => _adults;
            set => Set(ref _adults, value);
        }

        public int Children
        {
            get => _children;
            set => Set(ref _children, value);
        }

        public decimal Price
        {
            get => _price;
            set => Set(ref _price, value);
        }
        public FlightModel Flight { get; set;}
        public PassengerModel Passenger { get; set; }
        
        // public IList<int> SeatsOccupiedList {get {return _seatsOccupiedList; } internal set {
        // public int SeatsOccupied {get; set; }
    }
}
