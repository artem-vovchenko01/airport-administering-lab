using Entities;
using Mappers.Abstract;
using Model;

namespace Mappers
{
    public static class RouteMapper 
    {
        public static RouteModel MapToModel(Route entity)
        {
            var model = new RouteModel
            {
                Id = entity.Id,
                Carrier = entity.Carrier,
                Code = entity.Code,
                Airplane = AirplaneMapper.MapToModel(entity?.Airplane),
                AirportArrive = AirportMapper.MapToModel(entity?.AirportArrive),
                AirportDepart = AirportMapper.MapToModel(entity?.AirportDepart)
            };
            return model;
        }

        public static Route MapToEntity(RouteModel model)
        {
            var entity = new Route
            {
                Id = model.Id,
                Carrier = model.Carrier,
                Code = model.Code
            };
            return entity;
        }
    }
}