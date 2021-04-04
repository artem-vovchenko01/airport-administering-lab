using System;
using System.Collections.Generic;
using Entities;

namespace Data.Repositories.Abstract
{
    public interface ISeatRepository : IRepository<Seat, Guid>
    {
        List<Seat> SeatsOccupiedByTicketId(Guid ticketId);
        int SeatsOccupiedCountByTicketId(Guid ticketId);
    }
}
