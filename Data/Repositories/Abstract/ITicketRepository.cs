using System;
using System.Collections.Generic;
using Entities;

namespace Data.Repositories.Abstract
{
    public interface ITicketRepository : IRepository<Ticket, Guid>
    {
        IEnumerable<Ticket> GetTicketsByFlight(Flight flight);
        int GetTicketCountByFlight(Flight flight);
        IEnumerable<Ticket> GetAllWithIncludes();
    }
}
