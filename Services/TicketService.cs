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

        public IEnumerable<TicketModel> GetAllTickets()
        {
            var ticketModels = new List<TicketModel>();
            foreach (var ticket in _uof.Tickets.GetAll())
            {
                ticketModels.Add(TicketMapper.MapToModel(ticket));
            }

            return ticketModels;
        }

        public IEnumerable<TicketModel> SoldTickets(FlightModel flight)
        {
            var flightEntity = FlightMapper.MapToEntity(flight);
            var tickets =  _uof.Tickets.GetTicketsByFlight(flightEntity);
            var ticketModels = new List<TicketModel>();
            foreach (var ticket in tickets)
            {
                ticketModels.Add(TicketMapper.MapToModel(ticket)); 
            }

            return ticketModels;
        }
    }
}
