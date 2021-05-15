using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Repositories.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class RouteRepository : Repository<Route, Guid>, IRouteRepository
    {
        public RouteRepository(MyDbContext context) : base(context)
        {
        }
        
        public IEnumerable<Route> GetAllWithIncludes()
        {
            return _context.Routes
                .Include(r => r.Carrier)
                .Include(r => r.AirportArrive)
                .Include(r => r.AirportDepart);
        }

        public void RemoveByAirportId(Guid airportId)
        {
            var routes = _context.Routes
                .Where(r => r.AirportArrive.Id == airportId || r.AirportDepart.Id == airportId).ToList();
            foreach (var route in routes)
            {
                _context.Routes.Remove(route);
            }
        }
    }
}