using System;
using System.Collections.Generic;
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
            _uof.Complete();
        }

        public void RemovePassenger(Guid passengerId)
        {
            _uof.Passengers.Remove(_uof.Passengers.Get(passengerId));
            _uof.Complete();
        }

        public void EditPassenger(PassengerModel passenger)
        {
            var entity = PassengerMapper.MapToEntity(passenger);
            _uof.Passengers.Update(entity);
            _uof.Complete();
        }

        public IEnumerable<PassengerModel> GetAllPassengers()
        {
            var passengerModels = new List<PassengerModel>();
            foreach (var passenger in _uof.Passengers.GetAll())
            {
                passengerModels.Add(PassengerMapper.MapToModel(passenger));
            }

            return passengerModels;
        }
    }
}
