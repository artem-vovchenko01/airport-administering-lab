using System;
using System.Collections;
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
        public IEnumerable<Ticket> GetTicketsByFlight(Flight flight)
        {
            return MyDbContext.Tickets.Where(t => t.FlightId == flight.Id)
                .Include(t => t.SeatsOccupied)
                .Include(t => t.Flight)
                .Include(t => t.Passenger)
                .ToList();
        }

        public int GetTicketCountByFlight(Flight flight)
        {
            return MyDbContext.Tickets.Count(t => t.FlightId == flight.Id);
        }

        public IEnumerable<Ticket> GetAllWithIncludes()
        {
            return MyDbContext.Tickets
                .Include(t => t.SeatsOccupied)
                .Include(t => t.Flight)
                .Include(t => t.Passenger).ToList();
        }
    }
}