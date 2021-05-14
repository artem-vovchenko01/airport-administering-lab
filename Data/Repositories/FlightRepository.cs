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
        
        private MyDbContext _context => Context as MyDbContext;
        public Flight GetWithRouteAndAirplane(Guid id)
        {
            var flight = _context.Flights
                .Where(f => f.Id == id)
                .Include(f => f.Airplane)
                .Include(f => f.Route)
                .ThenInclude(r => r.Carrier)
                .FirstOrDefault();
            return flight;
        }

        public IEnumerable<Flight> GetAllWithRouteAndAirplane()
        {
            var objs = _context.Flights
                .Include(f => f.Airplane)
               .Include(f => f.Route)
               .Include(f => f.Route.Carrier)
               .Include(f => f.Route.AirportArrive)
               .Include(f => f.Route.AirportDepart)
               .ToList();
            return objs;
        }

        public IEnumerable<Flight> GetAllWithTickets()
        {
            return _context.Flights
                .Include(f => f.Tickets).ToList();
        }

        public int GetSeatCapacity(Guid flightId)
        {
            var flight = GetWithRouteAndAirplane(flightId);
            return flight.Airplane.Seats;
        }

    }
}
