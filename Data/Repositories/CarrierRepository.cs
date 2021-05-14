using System;
using System.Collections.Generic;
using System.Linq;
using Data.Repositories.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CarrierRepository : Repository<Carrier, Guid>, ICarrierRepository
    {
        public CarrierRepository(MyDbContext context) : base(context)
        {
        }

        public Carrier GetWithRoutes(Guid id)
        {
            return _context.Carriers
                .Where(c => c.Id == id)
                .Include(c => c.Routes)
                .FirstOrDefault();
        }

        public IEnumerable<Carrier> GetAllWithRoutes()
        {
            return _context.Carriers
                .Include(c => c.Routes);
        }
        
        private MyDbContext _context => Context as MyDbContext;
    }
}