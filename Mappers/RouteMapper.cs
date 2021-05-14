using Entities;
using Mappers.Abstract;
using Model;

namespace Mappers
{
    public class RouteMapper 
    {
        public RouteModel MapToModel(Route entity)
        {
            var airportMapper = new AirportMapper();
            var model = new RouteModel
            {
                Id = entity.Id,
                Carrier = new CarrierMapper().MapToModel(entity.Carrier),
                AirportArrive = airportMapper.MapToModel(entity?.AirportArrive),
                AirportDepart = airportMapper.MapToModel(entity?.AirportDepart)
            };
            return model;
        }

        public Route MapToEntity(RouteModel model)
        {
            var entity = new Route
            {
                Id = model.Id,
                CarrierId = model.Carrier.Id,
                AirportDepartId = model.AirportDepart.Id,
                AirportArriveId = model.AirportArrive.Id
            };
            return entity;
        }
    }
}