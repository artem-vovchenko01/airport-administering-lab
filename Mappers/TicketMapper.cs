using Entities;
using Mappers.Abstract;
using Model;

namespace Mappers
{
    public static class TicketMapper 
    {
        public static TicketModel MapToModel(Ticket entity)
        {
            var model = new TicketModel
            {
                Id = entity.Id,
                Adults = entity.Adults,
                Children = entity.Children,
                Price = entity.Price
            };
            return model;
        }

        public static Ticket MapToEntity(TicketModel model)
        {
            var entity = new Ticket
            {
                Id = model.Id,
                Adults = model.Adults,
                Children = model.Children,
                Price = model.Price
            };
            return entity;
        }
    }
}
