using System;
using System.Collections;
using System.Collections.Generic;
using Entities;

namespace Data.Repositories.Abstract
{
    public interface ICarrierRepository : IRepository<Carrier, Guid>
    {
        Carrier GetWithRoutes(Guid id);
        IEnumerable<Carrier> GetAllWithRoutes();
    }
}
