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

        public FlightModel Flight { get; set; }
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
                        break;
                }

                return error;
            }
        }
        // public IList<int> SeatsOccupiedList {get {return _seatsOccupiedList; } internal set {
        // public int SeatsOccupied {get; set; }
    }
}