﻿using System;
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
            _uof.Complete();
        }

        public void RemoveTicket(Guid ticketId)
        {
            _uof.Tickets.Remove(_uof.Tickets.Get(ticketId));
            _uof.Complete();
        }

        public void EditTicket(TicketModel ticket)
        {
            var entity = TicketMapper.MapToEntity(ticket);
            _uof.Tickets.Update(entity);
            _uof.Complete();
            UpdateTicketSeats(ticket);
        }

        private void UpdateTicketSeats(TicketModel ticket)
        {
            var newSeats = ticket.OccupiedSeats;
            var oldSeats = _uof.Seats.SeatsOccupiedByTicketId(ticket.Id);
            foreach (var oldSeat in oldSeats)
            {
                _uof.Seats.Remove(oldSeat);
            }

            _uof.Complete();
            foreach (var newSeat in newSeats)
            {
                _uof.Seats.Add(new Seat {SeatNumber = newSeat, TicketId = ticket.Id});
            }

            _uof.Complete();

        }

        public int SoldTicketsCount(FlightModel flight)
        {
            var flightEntity = FlightMapper.MapToEntity(flight);
            var tickets = new List<Ticket>(_uof.Tickets.GetAllWithIncludes());
            return tickets.Count;
        }

        public IEnumerable<TicketModel> GetAllTickets()
        {
            var ticketModels = new List<TicketModel>();
            foreach (var ticket in _uof.Tickets.GetAllWithIncludes())
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