using System;
using Data.Repositories.Abstract;
using Mappers;
using Model;
using Services.Abstract;

namespace Services
{
    public class PassengerService : IPassengerService
    {
        private readonly IUnitOfWork _uof;
        public PassengerService(IUnitOfWork uof)
        {
            _uof = uof;
        }
        public void AddPassenger(PassengerModel passenger)
        {
            var entity = PassengerMapper.MapToEntity(passenger);
            _uof.Passengers.Add(entity);
        }

        public void RemovePassenger(Guid passengerId)
        {
            _uof.Passengers.Remove(_uof.Passengers.Get(passengerId));
        }

        public void EditPassenger(PassengerModel passenger)
        {
            var entity = PassengerMapper.MapToEntity(passenger);
            _uof.Passengers.Update(entity);
        }

    }
}