using System;
using System.ComponentModel;

namespace Model
{
    public interface IModel<TKey> : INotifyPropertyChanged where TKey : IComparable<TKey>
    {
        public TKey Id { get; set; }
    }
}
