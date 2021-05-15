using System;
using System.Collections.Generic;

namespace Model
{
    public class TicketModel : AbstractModel
    {
        private int _adults;
        private int _children;
        private decimal _price;
        private FlightModel _flight;
        public List<int> OccupiedSeats { get; set; }

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

        public FlightModel Flight
        {
            get => _flight;
            set
            {
                if (_flight != null && value.Id != _flight.Id)
                {
                    OccupiedSeats = new List<int>();
                }
                _flight = value;
            }

        }
        public PassengerModel Passenger { get; set; }

        public override string this[string columnName]
        {
            get
            {
                string error = string.Empty;

                switch (columnName)
                {
                    case nameof(Adults):
                        if (Adults <= 0 || Adults < Children)
                            error =
                                "Number of adults should be greater than 0 and greater than or equal to number of children";
                        break;
                    case nameof(Children):
                        if (Children < 0 || Adults < Children)
                            error =
                                "Number of children should be not less than 0 and not greater than the number of adults";
                        break;
                    case nameof(Price):
                        if (Price <= 0)
                            error = "Price should be > 0";
                        if (Price < Flight.Airplane.DefaultPrice)
                            error = "Price of a ticket cannot be less than base airplane cost";
                        break;
                }

                return error;
            }
        }
        // public IList<int> SeatsOccupiedList {get {return _seatsOccupiedList; } internal set {
        // public int SeatsOccupied {get; set; }
    }
}