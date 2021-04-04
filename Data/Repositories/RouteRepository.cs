using System;
using System.Collections.Generic;
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
    }
}