using System;
using System.Collections;
using System.Collections.Generic;
using Entities;
using Model;

namespace Services.Abstract
{
    public interface ITicketService
    {
        void AddTicket(TicketModel ticket);
        void RemoveTicket(Guid ticketId);
        void EditTicket(TicketModel ticket);
        int SoldTicketsCount(FlightModel flight);
        IEnumerable<TicketModel> SoldTickets(FlightModel flight);
        IEnumerable<TicketModel> GetAllTickets();
    }
}
