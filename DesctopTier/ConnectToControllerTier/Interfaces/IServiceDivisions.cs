using ConnectToControllerTier.Models;
using System;

namespace ConnectToControllerTier.Interfaces
{
    public interface IServiceDivisions
    {
        DivisionDTO Get(Guid UID);
        ResponseModel Create(DivisionDTO division);
        ResponseModel Update(DivisionDTO division);
        ResponseModel Delete(Guid UID);
    }
}
