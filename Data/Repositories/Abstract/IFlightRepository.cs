using System;
using System.Collections.Generic;
using Entities;

namespace Data.Repositories.Abstract
{
    public interface IFlightRepository : IRepository<Flight, Guid>
    {
        Flight GetWithRouteAndAirplane(Guid id);
        IEnumerable<Flight> GetAllWithRouteAndAirplane();
        IEnumerable<Flight> GetAllWithTickets();
        int GetSeatCapacity(Guid flightId);
    }
}