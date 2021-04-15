using System;
using System.Linq;
using Entities;
using Mappers.Abstract;
using Model;

namespace Mappers
{
    public static class FlightMapper 
    {
        public static FlightModel MapToModel(Flight entity)
        {
            var model = new FlightModel
            {
                Id = entity.Id,
                MinDelayed = entity.MinDelayed,
                StopBooking = entity.StopBooking,
                TimeArrive = entity.TimeArrive,
                TimeDepart = entity.TimeDepart,
                Tickets = entity.Tickets?.Select(TicketMapper.MapToModel),
                RouteModel = RouteMapper.MapToModel(entity?.Route),
                TravelTime = entity.TimeArrive - entity.TimeDepart
            };
            return model;
        }
        

        public static Flight MapToEntity(FlightModel model)
        {
            var flight = new Flight
            {
                Id = model.Id,
                MinDelayed = model.MinDelayed,
                StopBooking = model.StopBooking,
                TimeArrive = model.TimeArrive,
                TimeDepart = model.TimeDepart,
                RouteId = model.RouteModel.Id
            };
            return flight;
        }
    }
}
