using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectToDataLibrary.Interfaces
{
    public interface IServiceEvents<T>
    {
        delegate void AddModel(T model);
        delegate void RemoveModel(Guid uid);
        delegate void UpdateModel(Guid uid, T model);

        event AddModel AddEvent;
        event RemoveModel RemoveEvent;
        event UpdateModel UpdateEvent;
    }
}
