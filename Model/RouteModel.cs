using System;

namespace Model
{
    public class RouteModel : AbstractModel
    {
        // private AirportModel _airportDepart;
        // private AirportModel _airportArrive;
        // private AirplaneModel _airplane;

        
        public CarrierModel Carrier { get; set; }

        public AirportModel AirportDepart { get; set; }
        public AirportModel AirportArrive { get; set; }


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
                }

                return error;
            }
        }
    }
}