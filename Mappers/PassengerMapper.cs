using Entities;
using Mappers.Abstract;
using Model;

namespace Mappers
{
    public static class PassengerMapper
    {
        public static PassengerModel MapToModel(Passenger entity)
        {
            var model = new PassengerModel
            {
                Id = entity.Id,
                Age = entity.Age,
                Name = entity.Name,
                Passport = entity.Passport,
                Surname = entity.Surname
            };
            return model;
        }

        public static Passenger MapToEntity(PassengerModel model)
        {
            var entity = new Passenger
            {
                Id = model.Id,
                Age = model.Age,
                Name = model.Name,
                Passport = model.Passport,
                Surname = model.Surname
            };
            return entity;
        }
    }
}