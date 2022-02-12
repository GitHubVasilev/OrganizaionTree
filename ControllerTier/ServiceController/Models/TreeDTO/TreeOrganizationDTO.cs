using System.Collections.Generic;

namespace ServiceController.Models.TreeDTO
{
    public class TreeOrganizationDTO
    {
        public TreeOrganizationDTO()
        {
            DivisionComponents = new();
            WorkerComponents = new();
        }

        public List<DivisionDTO> DivisionComponents;

        public List<WorkerDTO> WorkerComponents;
    }
}
