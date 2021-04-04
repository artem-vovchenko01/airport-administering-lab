using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Repositories.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class TicketRepository : Repository<Ticket, Guid>, ITicketRepository
    {
        public TicketRepository(MyDbContext context) : base(context)
        {
        }
        
        public MyDbContext MyDbContext => Context as MyDbContext;
        public List<Ticket> GetTicketsByFlight(Flight flight)
        {
            return MyDbContext.Tickets.Where(t => t.FlightId == flight.Id).ToList();
        }

        public int GetTicketCountByFlight(Flight flight)
        {
            return MyDbContext.Tickets.Count(t => t.FlightId == flight.Id);
        }

    }
}
