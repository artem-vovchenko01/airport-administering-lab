using System;
using System.Collections;
using System.Collections.Generic;
using Entities;

namespace Data.Repositories.Abstract
{
    public interface IRouteRepository : IRepository<Route, Guid>
    {
        IEnumerable<Route> GetAllWithIncludes();
    }
}
