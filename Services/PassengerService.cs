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
        private readonly PassengerMapper _passengerMapper;
        public PassengerService(IUnitOfWork uof)
        {
            _uof = uof;
            _passengerMapper = new PassengerMapper();
        }
        public void AddPassenger(PassengerModel passenger)
        {
            var entity = _passengerMapper.MapToEntity(passenger);
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
            var entity = _passengerMapper.MapToEntity(passenger);
            _uof.Passengers.Update(entity);
            _uof.Complete();
        }

        public IEnumerable<PassengerModel> GetAllPassengers()
        {
            var passengerModels = new List<PassengerModel>();
            foreach (var passenger in _uof.Passengers.GetAll())
            {
                passengerModels.Add(_passengerMapper.MapToModel(passenger));
            }

            return passengerModels;
        }
    }
}
