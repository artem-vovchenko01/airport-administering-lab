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
        private readonly AirplaneMapper _airplaneMapper;
        public AirplaneService(IUnitOfWork uof)
        {
            _uof = uof;
            _airplaneMapper = new AirplaneMapper();
        }
        public void AddAirplane(AirplaneModel airplane)
        {
            var entity = _airplaneMapper.MapToEntity(airplane);
            _uof.Airplanes.Add(entity);
            _uof.Complete();
        }

        public void EditAirplane(AirplaneModel airplane)
        {
            var entity = _airplaneMapper.MapToEntity(airplane);
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
                model = _airplaneMapper.MapToModel(airplane);
                models.Add(model);
            }

            return models;
        }
    }
}