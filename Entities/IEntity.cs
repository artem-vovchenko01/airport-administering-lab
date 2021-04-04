using System;

namespace Entities
{
    public interface IEntity<TKey> where TKey : IComparable<TKey>
    {
        public TKey Id { get; set; }
    }
}
