using System;
using Entities;
using Model;

namespace Mappers.Abstract
{
    public interface IMapper<E, M, K> where E : IEntity<K> where K : IComparable<K> where M : IModel<K>
    {
        M MapToModel(E entity);

        E MapToEntity(M model);
    }
}
