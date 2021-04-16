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


        public override string this[string columnName]
        {
            get
            {
                string error = string.Empty;

                switch (columnName)
                {
                    case nameof(Seats):
                        if (Seats <= 0)
                            error = "Number of seats should be >= 0";
                        break;
                    case nameof(DefaultPrice):
                        if (DefaultPrice <= 0)
                            error = "Default price should be >= 0";
                        break;
                    case nameof(Model):
                        if (string.IsNullOrWhiteSpace(Model))
                            error = "Blank value not allowed for the field" + nameof(Model);
                        break;
                    case nameof(Company):
                        if (string.IsNullOrWhiteSpace(Company))
                            error = "Blank value not allowed for the field" + nameof(Company);
                        break;
                }

                return error;
            }
        }
    }
}