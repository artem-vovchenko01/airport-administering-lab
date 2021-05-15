using System;
using Data;
using Data.Repositories.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class AirportRepository : Repository<Airport, Guid>, IAirportRepository
    {
        public AirportRepository(MyDbContext context) : base(context)
        {
        }
        
    }
}