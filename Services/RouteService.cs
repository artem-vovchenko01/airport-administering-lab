using System;
using System.Collections.Generic;
using Data.Repositories.Abstract;
using Mappers;
using Model;
using Services.Abstract;

namespace Services
{
    public class RouteService : IRouteService
    {
        private readonly IUnitOfWork _uof;
        private readonly RouteMapper _routeMapper;
        public RouteService(IUnitOfWork unitOfWork)
        {
            _uof = unitOfWork;
            _routeMapper = new RouteMapper();
        }

        public void AddRoute(RouteModel route)
        {
            var entity = _routeMapper.MapToEntity(route);
            _uof.Routes.Add(entity);
            _uof.Complete();
        }

        public void RemoveRoute(Guid routeId)
        {
            _uof.Routes.Remove(_uof.Routes.Get(routeId));
            _uof.Complete();
        }

        public void EditRoute(RouteModel route)
        {
            var entity = _routeMapper.MapToEntity(route);
            _uof.Routes.Update(entity);
            _uof.Complete();
        }

        public IEnumerable<RouteModel> GetAllRoutes()
        {
            var routeModels = new List<RouteModel>();
            foreach (var route in _uof.Routes.GetAllWithIncludes())
            {
                routeModels.Add(_routeMapper.MapToModel(route)); 
            }

            return routeModels;
        }
    }
}