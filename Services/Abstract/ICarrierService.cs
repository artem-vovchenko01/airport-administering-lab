using System;
using System.Collections.Generic;
using Model;

namespace Services.Abstract
{
    public interface ICarrierService
    {
        void AddCarrier(CarrierModel carrier);
        void RemoveCarrier(Guid carrierId);
        void EditCarrier(CarrierModel carrier);
        IEnumerable<CarrierModel> GetAllCarriers();
    }
}