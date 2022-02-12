using System;
using System.Collections.Generic;

namespace ConnectToDataLibrary.Interfaces
{
    public interface IService<T>
    {
        IEnumerable<T> GetAll();
        T Get(Guid uid);
        void Set(T model);
        void Update(Guid uid, T model);
        void Delete(Guid uid);
    }
}
