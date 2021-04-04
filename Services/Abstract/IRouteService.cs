using System;
using System.Collections.Generic;
using Model;

namespace Services.Abstract
{
    public interface IRouteService
    {
        void AddRoute(RouteModel route);
        void RemoveRoute(Guid routeId);
        void EditRoute(RouteModel route);
        IEnumerable<RouteModel> GetAllRoutes();
    }
}

