using Entities;
using Mappers.Abstract;
using Model;

namespace Mappers
{
    public static class AirplaneMapper 
    {
        public static AirplaneModel MapToModel(Airplane entity)
        {
            var model = new AirplaneModel
            {
                Id = entity.Id,
                Company = entity.Company,
                Model = entity.Model,
                DefaultPrice = entity.DefaultPrice
            };
            return model;
        }

        public static Airplane MapToEntity(AirplaneModel model)
        {
            var entity = new Airplane
            {
                Id = model.Id,
                Company = model.Company,
                Model = model.Model,
                DefaultPrice = model.DefaultPrice
            };
            return entity;
        }
    }
}