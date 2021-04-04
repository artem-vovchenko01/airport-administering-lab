using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Repositories.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class FlightRepository : Repository<Flight, Guid>, IFlightRepository
    {
        public FlightRepository(MyDbContext context) : base(context)
        {
        }
        
        private MyDbContext _Context => Context as MyDbContext;
        public Flight GetWithRouteAndAirplane(Guid id)
        {
            var flight = _Context.Flights
                .Where(f => f.Id == id)
                .Include(f => f.Route)
                .ThenInclude(r => r.Airplane)
                .FirstOrDefault();
            return flight;
        }

        public IEnumerable<Flight> GetAllWithRouteAndAirplane()
        {
             return _Context.Flights
                .Include(f => f.Route)
                .Include(f => f.Route.Airplane)
                .Include(f => f.Route.AirportArrive)
                .Include(f => f.Route.AirportDepart)
                .ToList();
        }

        public IEnumerable<Flight> GetAllWithTickets()
        {
            return _Context.Flights
                .Include(f => f.Tickets).ToList();
        }

        public int GetSeatCapacity(Guid flightId)
        {
            var flight = GetWithRouteAndAirplane(flightId);
            return flight.Route.Airplane.Seats;
        }

    }
}
