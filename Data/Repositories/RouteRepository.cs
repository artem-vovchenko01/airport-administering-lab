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
        
        public MyDbContext MyDbContext => Context as MyDbContext;
        public IEnumerable<Route> GetAllWithIncludes()
        {
            return MyDbContext.Routes
                .Include(r => r.Airplane)
                .Include(r => r.AirportArrive)
                .Include(r => r.AirportDepart);
        }

        public void RemoveByAirportId(Guid airportId)
        {
            var routes = MyDbContext.Routes
                .Where(r => r.AirportArrive.Id == airportId || r.AirportDepart.Id == airportId).ToList();
            foreach (var route in routes)
            {
                MyDbContext.Routes.Remove(route);
            }
        }
    }
}