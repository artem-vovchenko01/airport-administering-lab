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
        private IUnitOfWork _uof;
        public RouteService(IUnitOfWork unitOfWork)
        {
            _uof = unitOfWork;
        }

        public void AddRoute(RouteModel route)
        {
            var entity = RouteMapper.MapToEntity(route);
            _uof.Routes.Add(entity);
        }

        public void RemoveRoute(Guid routeId)
        {
            _uof.Routes.Remove(_uof.Routes.Get(routeId));
        }

        public void EditRoute(RouteModel route)
        {
            var entity = RouteMapper.MapToEntity(route);
            _uof.Routes.Update(entity);
        }

        public IEnumerable<RouteModel> GetAllRoutes()
        {
            var routeModels = new List<RouteModel>();
            foreach (var route in _uof.Routes.GetAllWithIncludes())
            {
                routeModels.Add(RouteMapper.MapToModel(route)); 
            }

            return routeModels;
        }
    }
}