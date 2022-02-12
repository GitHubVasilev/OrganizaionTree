using ConnectToDataLibrary.Models;
using ContollerLibrary.Interfaces;
using ControllerLibrary.Models.Divisions;
using ControllerLibrary.Models.Workers;
using ServiceController.Models.TreeDTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceController.Fuctories
{
    public class DivisionFactory
    {
        public DivisionDTO CreateViewModel(BaseDivision model) 
        {
            WorkerFactory workerFactory = new WorkerFactory();
            List<WorkerDTO> listWorkers = new List<WorkerDTO>();
            List<DivisionDTO> listDivision = new List<DivisionDTO>();

            foreach (BaseWorker worker in model.ComponentsOrganization.Where(m => !m.IsComposite)) 
            {
                listWorkers.Add(workerFactory.CreateViewModel(worker));
            }

            foreach (BaseDivision division in model.ComponentsOrganization.Where(m => m.IsComposite)) 
            {
                listDivision.Add(CreateViewModel(division));
            }

            return new DivisionDTO
            {
                UID = model.UID,
                Name = model.Name,
                TypeComponent = model.TypeComponent,
                DivisionsDTO = listDivision,
                WorkersDTO = listWorkers
            };
        }

        public IComponentOrganization CreateModel(DivisionDTO dto) 
        {
            WorkerFactory workerFactory = new WorkerFactory();
            List<IComponentOrganization> componentns = new List<IComponentOrganization>();

            foreach (WorkerDTO worker in dto.WorkersDTO) 
            {
                componentns.Add(workerFactory.CreateModel(worker));
            }

            foreach (DivisionDTO division in dto.DivisionsDTO) 
            {
                switch (division.TypeComponent) 
                {
                    case TypeComponent.Department:
                        componentns.Add(CreateModel(division) as BaseDivision);
                        break;
                    case TypeComponent.Institution:
                        componentns.Add(CreateModel(division) as BaseDivision);
                        break;
                    default:
                        throw new NotImplementedException("Я забил, мне лень это описывать");
                }
            }

            BaseDivision result;

            switch (dto.TypeComponent)
            {
                case TypeComponent.Department:
                    result = new Department 
                    {
                        Name = dto.Name,
                        UID = dto.UID,
                        ComponentsOrganization = componentns
                    };
                    break;
                case TypeComponent.Institution:
                    result = new Institution
                    {
                        Name = dto.Name,
                        UID = dto.UID,
                        ComponentsOrganization = componentns
                    };
                    break;
                default:
                    throw new NotImplementedException("И здесь тоже забил");
            }

            return result;
        }
    }
}
