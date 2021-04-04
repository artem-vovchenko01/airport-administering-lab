using Entities;
using Mappers.Abstract;
using Model;

namespace Mappers
{
    public static class AirportMapper 
    {
        public static AirportModel MapToModel(Airport entity)
        {
            var model = new AirportModel
            {
                Id = entity.Id,
                City = entity.City,
                Country = entity.Country,
                Name = entity.Name
            };
            return model;
        }

        public static Airport MapToEntity(AirportModel model)
        {
            var entity = new Airport
            {
                Id = model.Id,
                City = model.City,
                Country = model.Country,
                Name = model.Name
            };
            return entity;
        }
    }
}
