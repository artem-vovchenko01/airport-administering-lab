using System;
using System.Collections.Generic;
using Data.Repositories.Abstract;
using Mappers;
using Model;
using Services.Abstract;

namespace Services
{
    public class CarrierService : ICarrierService
    {
        private readonly IUnitOfWork _uof;
        private readonly CarrierMapper _carrierMapper;

        public CarrierService(IUnitOfWork uof)
        {
            _uof = uof;
            _carrierMapper = new CarrierMapper();
        }
        
        public void AddCarrier(CarrierModel carrier)
        {
            var entity = _carrierMapper.MapToEntity(carrier);
            _uof.Carriers.Add(entity);
            _uof.Complete();
        }

        public void RemoveCarrier(Guid carrierId)
        {
            _uof.Carriers.Remove(_uof.Carriers.Get(carrierId));
            _uof.Complete();
        }

        public void EditCarrier(CarrierModel carrier)
        {
            var entity = _carrierMapper.MapToEntity(carrier);
            _uof.Carriers.Update(entity);
            _uof.Complete();
        }

        public IEnumerable<CarrierModel> GetAllCarriers()
        {
            var carrierModels = new List<CarrierModel>();
            foreach (var carrier in _uof.Carriers.GetAllWithRoutes())
            {
                carrierModels.Add(_carrierMapper.MapToModel(carrier)); 
            }

            return carrierModels;
        }
    }
}