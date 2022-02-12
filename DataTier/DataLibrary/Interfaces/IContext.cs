using DataLibrary.Models;
using System.Collections.Generic;

namespace DataLibrary.Interfaces
{
    public interface IContext
    {
        List<DivisionModel> Departments { get; }
        List<WorkerModel> Workers { get; }
    }
}
