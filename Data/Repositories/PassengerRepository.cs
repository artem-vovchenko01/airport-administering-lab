using System;
using Data;
using Data.Repositories.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class PassengerRepository : Repository<Passenger, Guid>, IPassengerRepository
    {
        public PassengerRepository(MyDbContext context) : base(context)
        {
        }
        
    }
}