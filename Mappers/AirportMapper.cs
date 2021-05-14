using Entities;
using Mappers.Abstract;
using Model;

namespace Mappers
{
    public class AirportMapper 
    {
        public AirportModel MapToModel(Airport entity)
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

        public Airport MapToEntity(AirportModel model)
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
