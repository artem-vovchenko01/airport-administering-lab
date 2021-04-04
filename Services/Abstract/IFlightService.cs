using System;
using System.Collections.Generic;
using Entities;
using Model;

namespace Services.Abstract
{
    public interface IFlightService
    {
        void AddFlight(FlightModel flight);
        void RemoveFlight(Guid flightId);
        void EditFlight(FlightModel flightModel);
        void DelayFlight(FlightModel flight, int min);
        int SeatsAvailableCount(FlightModel flight);
        bool IsSeatAvailable(FlightModel flight, int seat);
        IEnumerable<int> SeatsAvailable(FlightModel flight);
        IEnumerable<FlightModel> GetAllFlights();
    }
}
