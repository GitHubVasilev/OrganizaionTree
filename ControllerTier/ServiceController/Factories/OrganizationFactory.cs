using ContollerLibrary.Interfaces;
using ControllerLibrary.Models.Divisions;
using ControllerLibrary.Models.Workers;
using ServiceController.Models.TreeDTO;
using System.Collections.Generic;
using System.Linq;

namespace ServiceController.Fuctories
{
    public class OrganizationFactory
    {
        public TreeOrganizationDTO CreateDTO(ITree organization) 
        {
            WorkerFactory workerFactory = new WorkerFactory();
            DivisionFactory divisionFactory = new DivisionFactory();

            List<DivisionDTO> divisionsVM = new List<DivisionDTO>();
            List<WorkerDTO> workersVM = new List<WorkerDTO>();

            foreach (BaseDivision division in organization.ComponentsOrganization.Where(m => m.IsComposite)) 
            {
                divisionsVM.Add(divisionFactory.CreateViewModel(division));
            }

            foreach (BaseWorker worker in organization.ComponentsOrganization.Where(m => !m.IsComposite)) 
            {
                workersVM.Add(workerFactory.CreateViewModel(worker));
            }

            return new TreeOrganizationDTO()
            {
                DivisionComponents = divisionsVM,
                WorkerComponents = workersVM
            };
        }
    }
}
