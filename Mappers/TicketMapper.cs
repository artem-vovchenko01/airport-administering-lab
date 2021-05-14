using System.Collections.Generic;
using System.Linq;
using Entities;
using Mappers.Abstract;
using Model;

namespace Mappers
{
    public class TicketMapper 
    {
        public TicketModel MapToModel(Ticket entity)
        {
            var model = new TicketModel
            {
                Id = entity.Id,
                Adults = entity.Adults,
                Children = entity.Children,
                Price = entity.Price,
                Flight = new FlightMapper().MapToModel(entity.Flight),
                Passenger = new PassengerMapper().MapToModel(entity.Passenger),
                OccupiedSeats = entity.SeatsOccupied.Select(s => s.SeatNumber).ToList()
            };
            return model;
        }

        public Ticket MapToEntity(TicketModel model)
        {
            var seats = new List<Seat>();
            foreach (var seatNum in model.OccupiedSeats)
            {
                seats.Add(new Seat {TicketId = model.Id, SeatNumber = seatNum});
            }
            var entity = new Ticket
            {
                Id = model.Id,
                Adults = model.Adults,
                Children = model.Children,
                Price = model.Price,
                FlightId = model.Flight.Id,
                PassengerId = model.Passenger.Id,
                SeatsOccupied = seats
            };
            return entity;
        }
    }
}
