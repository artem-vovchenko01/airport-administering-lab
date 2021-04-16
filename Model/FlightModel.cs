using System;
using System.Collections.Generic;
using System.ComponentModel;

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

        public TimeSpan TravelTime { get; set; }

        public RouteModel RouteModel
        {
            get => _routeModel;
            set => Set(ref _routeModel, value);
        }

        public override string this[string columnName]
        {
            get
            {
                string error = string.Empty;

                switch (columnName)
                {
                    case nameof(TimeDepart):
                        if (TimeArrive != null)
                        {
                            if (TimeDepart >= TimeArrive)
                                error = "Time of departure should come before arrival";
                            else if ((TimeArrive - TimeDepart).TotalDays >= 1)
                                error = "One flight cannot last >= 24 hours";
                        }

                        break;

                    case nameof(TimeArrive):
                        if (TimeDepart != null)
                        {
                            if (TimeDepart >= TimeArrive)
                                error = "Time of departure should come before arrival";
                            else if ((TimeArrive - TimeDepart).TotalDays >= 1)
                                error = "One flight cannot last >= 24 hours";
                        }

                        break;
                    case nameof(MinDelayed):
                        if (MinDelayed < 0)
                            error = "Value for " + nameof(MinDelayed) + " could not be < 0";
                        break;
                    case nameof(StopBooking):
                        if (StopBooking > TimeDepart.Add(new TimeSpan(0, MinDelayed, 0)))
                            error =
                                "Stop booking date should not come after the flight will depart (counting delay time)";
                        break;
                }

                return error;
            }
        }
    }
}