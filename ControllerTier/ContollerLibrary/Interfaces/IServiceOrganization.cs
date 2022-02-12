using ConnectToDataLibrary.Interfaces;
using ConnectToDataLibrary.Models;

namespace ContollerLibrary.Interfaces
{
    public interface IServiceOrganization
    {
        ITree Organization { get; }
        IService<DivisionModel> ServiceDivisions { get; }
        IService<WorkerModel> ServiceWorkers { get; }
    }
}
