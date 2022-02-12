using ConnectToControllerTier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectToControllerTier.Interfaces
{
    public interface IServiceWorkers
    {
        WorkerDTO Get(Guid UID);
        ResponseModel Create(WorkerDTO worker);
        ResponseModel Update(WorkerDTO worker);
        ResponseModel Delete(Guid UID);
    }
}
