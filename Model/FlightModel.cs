using System;
using System.Collections.Generic;

namespace Model
{
    public class FlightModel : AbstractModel
    {
        private DateTime _timeDepart;
        private DateTime _timeArrive;
        private DateTime _stopBooking;
        private int _minDelayed;
        private RouteModel _routeModel;
        private int _seatsAvailable;
        // private AirportModel _airportModel;

        public IEnumerable<TicketModel> Tickets { get; set; }

        // public AirportModel AirportModel
        // {
        //     get => _airportModel;
        //     set => Set(ref _airportModel, value);
        // }

        public int SeatsAvailable
        {
            get => _seatsAvailable;
            set => Set(ref _seatsAvailable, value);
        }

        public DateTime TimeDepart
        {
            get => _timeDepart;
            set => Set(ref _timeDepart, value);
        }
        
        public DateTime TimeArrive
        {
            get => _timeArrive;
            set => Set(ref _timeArrive, value);
        }
        public DateTime StopBooking
        {
            get => _stopBooking;
            set => Set(ref _stopBooking, value);
        }
        public int MinDelayed
        {
            get => _minDelayed;
            set => Set(ref _minDelayed, value);
        }

        public RouteModel RouteModel
        {
            get => _routeModel;
            set => Set(ref _routeModel, value);
        }
    }
}