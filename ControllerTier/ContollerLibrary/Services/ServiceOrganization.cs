using ConnectToDataLibrary.Interfaces;
using ConnectToDataLibrary.Models;
using ContollerLibrary.EventHendlers;
using ContollerLibrary.Infrastructure;
using ContollerLibrary.Interfaces;
using ControllerLibrary.Models.Divisions;
using CRM_Controller.Models.Divisions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContollerLibrary.Services
{
    public class ServiceOrganization : IServiceOrganization
    {
        public ITree Organization { get; }
        public IService<DivisionModel> ServiceDivisions { get; }
        public IService<WorkerModel> ServiceWorkers { get; }

        private readonly DivisionEventsHendlers _divisionEvents;
        private readonly WorkerEventsHendlers _workerEvents;

        public ServiceOrganization(
            IService<DivisionModel> divisionService,
            IService<WorkerModel> workerService)
        {
            ServiceDivisions = divisionService;
            ServiceWorkers = workerService;

            IEnumerable<DivisionModel> divisionModels = ServiceDivisions.GetAll();
            IEnumerable<WorkerModel> workerModels = ServiceWorkers.GetAll();

            Organization = CreateTree(divisionModels, workerModels);

            _divisionEvents = new(ServiceDivisions as IServiceEvents<DivisionModel>, Organization);
            _workerEvents = new(ServiceWorkers as IServiceEvents<WorkerModel>, Organization);

        }

        private ITree CreateTree(IEnumerable<DivisionModel> _departmentModels, IEnumerable<WorkerModel> _workerModels)
        {
            TreeOrganization tree = new TreeOrganization();
            // Стек подразделений в дереве
            Stack<BaseDivision> stackComponent = new Stack<BaseDivision>();

            // Добавление подразделений верхнего уровня в стек и список подразделений верхнего уровня
            foreach (DivisionModel divisionModel in _departmentModels
                                                .Where(m => m.UIDParant == Guid.Empty))
            {
                BaseDivision division = DivisionConverter.CreateComponent(divisionModel, null);
                tree.ComponentsOrganization.Add(division);
                stackComponent.Push(division);
            }

            while (stackComponent.Count > 0)
            {
                // Извлекает из стека последний элемент
                BaseDivision currentDepartment = stackComponent.Pop();

                // Добавляет в подразделение сотрудников, найденные в репозитории
                foreach (WorkerModel worker in _workerModels.Where(m => m.Department == currentDepartment.UID))
                {
                    currentDepartment.ComponentsOrganization.Add(WorkerConverter.CreateComponent(worker, currentDepartment));
                }

                // Добавляет в стек и подразделение список подразделений найденных в репозитории
                foreach (DivisionModel division in _departmentModels.Where(m => m.UIDParant == currentDepartment.UID))
                {
                    BaseDivision department = DivisionConverter.CreateComponent(division, currentDepartment);
                    currentDepartment.ComponentsOrganization.Add(department);
                    stackComponent.Push(department);
                }
            }

            return tree;
        }
    }
}
