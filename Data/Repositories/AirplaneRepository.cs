using System;
using Data;
using Data.Repositories.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class AirplaneRepository : Repository<Airplane, Guid>, IAirplaneRepository
    {
        public AirplaneRepository(MyDbContext context) : base(context)
        {
        }
        
    }
}
