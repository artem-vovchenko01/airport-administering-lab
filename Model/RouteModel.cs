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
    }
}
