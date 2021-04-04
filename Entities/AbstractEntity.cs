using System;

namespace Entities
{
    public abstract class AbstractEntity : IEntity<Guid>
    {
        public Guid Id { get; set; }
    }
}
