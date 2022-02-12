using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectToControllerTier.Models.TreeDTO
{
    public class TreeOrganizationDTO
    {
        public TreeOrganizationDTO()
        {
            DivisionComponents = new();
            WorkerComponents = new();
        }

        public List<DivisionComponent> DivisionComponents;

        public List<WorkerComponent> WorkerComponents;
    }
}
