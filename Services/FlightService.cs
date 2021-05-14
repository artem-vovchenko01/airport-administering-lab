using System;
using System.Collections.Generic;
using System.Linq;
using Data.Repositories.Abstract;
using Mappers;
using Model;
using Services.Abstract;

namespace Services
{
    public class FlightService : IFlightService
    {
        private readonly IUnitOfWork _uof;
        private readonly TicketService _ticketService;
        private readonly FlightMapper _flightMapper;
        public FlightService(IUnitOfWork uof)
        {
            _uof = uof;
            _ticketService = new TicketService(uof);
            _flightMapper = new FlightMapper();
        }

        public void AddFlight(FlightModel flight)
        {
            var entity = _flightMapper.MapToEntity(flight);
            _uof.Flights.Add(entity);
            _uof.Complete();
        }

        public void RemoveFlight(Guid flightId)
        {
            _uof.Flights.Remove(_uof.Flights.Get(flightId));
            _uof.Complete();
        }

        public void EditFlight(FlightModel flightModel)
        {
            var entity = _flightMapper.MapToEntity(flightModel);
            _uof.Flights.Update(entity);
            _uof.Complete();
        }

        public void DelayFlight(FlightModel flight, int min)
        {
            flight.MinDelayed = min;
            var entity = _flightMapper.MapToEntity(flight);
            _uof.Flights.Update(entity);
            _uof.Complete();
        }

        public int SeatsAvailableCount(FlightModel flight)
        {
            int maxSeats = _uof.Flights.GetSeatCapacity(flight.Id);
            int occupied = 0;
            foreach (var t in _ticketService.SoldTickets(flight))
            {
                occupied += _uof.Seats.SeatsOccupiedCountByTicketId(t.Id);
            }

            return maxSeats - occupied;
        }

        public bool IsSeatAvailable(FlightModel flight, int seat)
        {
            return SeatsAvailable(flight).Contains(seat);
        }

        public IEnumerable<int> SeatsAvailable(FlightModel flight)
        {
            var avail = new HashSet<int>(Enumerable.Range(1, _uof.Flights.GetSeatCapacity(flight.Id)));
            foreach (var ticket in _ticketService.SoldTickets(flight))
            {
                foreach (var seat in _uof.Seats.SeatsOccupiedByTicketId(ticket.Id))
                {
                    avail.Remove(seat.SeatNumber);
                } 
            }

            return avail.ToList();
        }

        public IEnumerable<FlightModel> GetAllFlights()
        {
            var models = new List<FlightModel>();
            FlightModel model;

            foreach (var flight in _uof.Flights.GetAllWithRouteAndAirplane())
            {
                model = _flightMapper.MapToModel(flight);
                model.SeatsAvailable = SeatsAvailableCount(model);
                models.Add(model);
            }

            return models;
        }
    }
 }
       