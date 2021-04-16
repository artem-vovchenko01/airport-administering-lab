using System;
using System.Collections.Generic;
using Data.Repositories.Abstract;
using Mappers;
using Model;
using Services.Abstract;

namespace Services
{
    public class AirportService : IAirportService
    {
        private readonly IUnitOfWork _uof;
        public AirportService(IUnitOfWork uof)
        {
            _uof = uof;
        }
            
        public void AddAirport(AirportModel airport)
        {
            var entity = AirportMapper.MapToEntity(airport);
            _uof.Airports.Add(entity);
            _uof.Complete();
        }

        public void RemoveAirport(Guid airportId)
        {
            _uof.Airports.Remove(_uof.Airports.Get(airportId));
            _uof.Complete();
            _uof.Routes.RemoveByAirportId(airportId);
            _uof.Complete();
        }

        public void EditAirport(AirportModel airport)
        {
            var entity = AirportMapper.MapToEntity(airport);
            _uof.Airports.Update(entity);
            _uof.Complete();
        }

        public IEnumerable<AirportModel> GetAllAirports()
        {
            var models = new List<AirportModel>();
            AirportModel model;
            foreach (var airport in _uof.Airports.GetAll())
            {
                model = AirportMapper.MapToModel(airport);
                models.Add(model);
            }

            return models;
        }
    }
}