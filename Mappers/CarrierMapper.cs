using System;
using Entities;
using Mappers.Abstract;
using Model;

namespace Mappers
{
    public class CarrierMapper : IMapper<Carrier, CarrierModel, Guid>
    {
        public CarrierModel MapToModel(Carrier entity)
        {
            return new CarrierModel
            {
                Id = entity.Id,
                Name = entity.Name,
                
            };
        }

        public Carrier MapToEntity(CarrierModel model)
        {
            return new Carrier
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}