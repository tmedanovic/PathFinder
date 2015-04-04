using System;
using System.Collections.Generic;

namespace PathFinder.WinForms.Tracking
{
    public interface IGenericRepository<T>
    {
        event EventHandler<EventArgs> Changed;

        void Load();

        void Save();

        void Add(T item);

        void Remove(T item);

        IEnumerable<T> GetAll();
    }
}
