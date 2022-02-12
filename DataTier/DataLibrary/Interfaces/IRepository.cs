using System;
using System.Collections.Generic;

namespace DataLibrary.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(Guid UID);
        void Create(T model);
        void Update(Guid UID, T model);
        void Delete(Guid UID);
    }
}
