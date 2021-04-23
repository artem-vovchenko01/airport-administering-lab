using System.Collections.Generic;
using System.Linq;
using Entities;
using Mappers.Abstract;
using Model;

namespace Mappers
{
    public static class TicketMapper 
    {
        public static TicketModel MapToModel(Ticket entity)
        {
            var model = new TicketModel
            {
                Id = entity.Id,
                Adults = entity.Adults,
                Children = entity.Children,
                Price = entity.Price,
                Flight = FlightMapper.MapToModel(entity.Flight),
                Passenger = PassengerMapper.MapToModel(entity.Passenger),
                OccupiedSeats = entity.SeatsOccupied.Select(s => s.SeatNumber).ToList()
            };
            return model;
        }

        public static Ticket MapToEntity(TicketModel model)
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
