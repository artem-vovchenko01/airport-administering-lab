using System;
using System.Collections.Generic;
using Data.Repositories.Abstract;
using Entities;
using Mappers;
using Model;
using Services.Abstract;

namespace Services
{
    public class TicketService : ITicketService
    {
        private readonly IUnitOfWork _uof;
        public TicketService(IUnitOfWork uof)
        {
            _uof = uof;
        }

        public void AddTicket(TicketModel ticket)
        {
            var entity = TicketMapper.MapToEntity(ticket);
            _uof.Tickets.Add(entity);
        }

        public void RemoveTicket(Guid ticketId)
        {
            _uof.Tickets.Remove(_uof.Tickets.Get(ticketId));
        }

        public void EditTicket(TicketModel ticket)
        {
            var entity = TicketMapper.MapToEntity(ticket);
            _uof.Tickets.Update(entity);
        }

        public int SoldTicketsCount(FlightModel flight)
        {
            var flightEntity = FlightMapper.MapToEntity(flight);
            return _uof.Tickets.GetTicketsByFlight(flightEntity).Count;
        }

        public IEnumerable<Ticket> SoldTickets(FlightModel flight)
        {
            var flightEntity = FlightMapper.MapToEntity(flight);
            return _uof.Tickets.GetTicketsByFlight(flightEntity);
        }
    }
}
