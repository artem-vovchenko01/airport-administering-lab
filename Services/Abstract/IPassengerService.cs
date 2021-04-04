using System;
using Entities;
using Model;

namespace Services.Abstract
{
    public interface IPassengerService
    {
        void AddPassenger(PassengerModel passenger);
        void RemovePassenger(Guid passengerId);
        void EditPassenger(PassengerModel passenger);
    }
}
