using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContollerLibrary.Interfaces
{
    public interface ITree
    {
        List<IComponentOrganization> ComponentsOrganization { get; }
        IComponentOrganization Search(Guid UID);
    }
}
