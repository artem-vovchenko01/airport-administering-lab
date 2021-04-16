using System;

namespace Model
{
    public class RouteModel : AbstractModel
    {
        private string _carrier;

        private string _code;
        // private AirportModel _airportDepart;
        // private AirportModel _airportArrive;
        // private AirplaneModel _airplane;

        public string Carrier
        {
            get => _carrier;
            set => Set(ref _carrier, value);
        }

        public string Code
        {
            get => _code;
            set => Set(ref _code, value);
        }

        public AirportModel AirportDepart { get; set; }
        public AirportModel AirportArrive { get; set; }
        public AirplaneModel Airplane { get; set; }


        public override string this[string columnName]
        {
            get
            {
                string error = string.Empty;

                switch (columnName)
                {
                    case nameof(AirportDepart):
                        if (AirportArrive == AirportDepart)
                            error = "Departure and arrival airports could not be the same";
                        break;
                    case nameof(AirportArrive):
                        if (AirportArrive == AirportDepart)
                            error = "Departure and arrival airports could not be the same";
                        break;
                    case nameof(Carrier):
                        if (string.IsNullOrWhiteSpace(Carrier))
                            error = "Blank value not allowed for the field" + nameof(Carrier);
                        break;
                    case nameof(Code):
                        if (string.IsNullOrWhiteSpace(Code))
                            error = "Blank value not allowed for the field" + nameof(Code);
                        break;
                }

                return error;
            }
        }
    }
}