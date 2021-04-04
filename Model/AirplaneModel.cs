using System;

namespace Model
{
    public class AirplaneModel : AbstractModel
    {
        private string _company;
        private string _model;
        private int _seats;
        private int _defaultPrice;
        public string Company 
        {
            get => _company;
            set => Set(ref _company, value); 
        }

        public string Model
        {
            get => _model;
            set => Set(ref _model, value);
        }

        public int Seats
        {
            get => _seats;
            set => Set(ref _seats, value);
        }

        public int DefaultPrice
        {
            get => _defaultPrice;
            set => Set(ref _defaultPrice, value);
        }
    }
}