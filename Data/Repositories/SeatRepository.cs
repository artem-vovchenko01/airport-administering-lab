using System;
using System.Collections.Generic;
using System.Linq;
using Data.Repositories.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class SeatRepository : Repository<Seat, Guid>, ISeatRepository
    {
        public SeatRepository(MyDbContext context) : base(context)
        {
        }
        public List<Seat> SeatsOccupiedByTicketId(Guid ticketId)
        {
            var ticket = _context.Tickets.Where(t => t.Id == ticketId)
                .Include(t => t.SeatsOccupied).FirstOrDefault();
            return ticket.SeatsOccupied;
        }

        public int SeatsOccupiedCountByTicketId(Guid ticketId)
        {
            return SeatsOccupiedByTicketId(ticketId).Count();
        }
    }
}
