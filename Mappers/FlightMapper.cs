using System;
using System.Linq;
using Entities;
using Mappers.Abstract;
using Model;

namespace Mappers
{
    public class FlightMapper 
    {
        public FlightModel MapToModel(Flight entity)
        {
            var ticketMapper = new TicketMapper();
            var model = new FlightModel
            {
                Id = entity.Id,
                Code = entity.Code,
                MinDelayed = entity.MinDelayed,
                StopBooking = entity.StopBooking,
                TimeArrive = entity.TimeArrive,
                TimeDepart = entity.TimeDepart,
                Tickets = entity.Tickets?.Select(ticketMapper.MapToModel),
                RouteModel = new RouteMapper().MapToModel(entity?.Route),
                Airplane = new AirplaneMapper().MapToModel(entity.Airplane),
                TravelTime = entity.TimeArrive - entity.TimeDepart,
                DelayReason = entity.DelayReason
            };
            return model;
        }
        
        public Flight MapToEntity(FlightModel model)
        {
            var flight = new Flight
            {
                Id = model.Id,
                Code = model.Code,
                MinDelayed = model.MinDelayed,
                StopBooking = model.StopBooking,
                TimeArrive = model.TimeArrive,
                TimeDepart = model.TimeDepart,
                RouteId = model.RouteModel.Id,
                AirplaneId = model.Airplane.Id,
                DelayReason = model.DelayReason
            };
            return flight;
        }
    }
}
