using System;
using System.Collections.Generic;
using Data.Repositories.Abstract;
using Entities;
using Mappers;
using Model;
using Services.Abstract;

namespace Services
{
    public class AirplaneService : IAirplaneService
    {
        private readonly IUnitOfWork _uof;
        public AirplaneService(IUnitOfWork uof)
        {
            _uof = uof;
        }
        public void AddAirplane(AirplaneModel airplane)
        {
            var entity = AirplaneMapper.MapToEntity(airplane);
            _uof.Airplanes.Add(entity);
            _uof.Complete();
        }

        public void EditAirplane(AirplaneModel airplane)
        {
            var entity = AirplaneMapper.MapToEntity(airplane);
            _uof.Airplanes.Update(entity);
            _uof.Complete();
        }

        public void RemoveAirplane(Guid airplaneId)
        {
            _uof.Airplanes.Remove(_uof.Airplanes.Get(airplaneId));
            _uof.Complete();
        }

        public IEnumerable<AirplaneModel> GetAllAirplanes()
        {
            var models = new List<AirplaneModel>();
            AirplaneModel model;
            foreach (var airplane in _uof.Airplanes.GetAll())
            {
                model = AirplaneMapper.MapToModel(airplane);
                models.Add(model);
            }

            return models;
        }
    }
}