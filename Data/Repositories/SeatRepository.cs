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
        public SeatRepository(DbContext context) : base(context)
        {
        }
        public MyDbContext MyDbContext => Context as MyDbContext;
        public List<Seat> SeatsOccupiedByTicketId(Guid ticketId)
        {
            var ticket = MyDbContext.Tickets.Where(t => t.Id == ticketId)
                .Include(t => t.SeatsOccupied).FirstOrDefault();
            return ticket.SeatsOccupied;
        }

        public int SeatsOccupiedCountByTicketId(Guid ticketId)
        {
            return SeatsOccupiedByTicketId(ticketId).Count();
        }
    }
}
