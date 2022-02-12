using ConnectToDataLibrary.Interfaces;
using ConnectToDataLibrary.Models;
using ContollerLibrary.Infrastructure;
using ContollerLibrary.Interfaces;
using ControllerLibrary.Models.Divisions;
using System;

namespace ContollerLibrary.EventHendlers
{
    class WorkerEventsHendlers
    {
        private readonly IServiceEvents<WorkerModel> _serviceEvents;
        private readonly ITree _tree;

        public WorkerEventsHendlers(IServiceEvents<WorkerModel> serviceEvents, ITree tree)
        {
            this._tree = tree;
            this._serviceEvents = serviceEvents;

            _serviceEvents.AddEvent += _serviceEvents_AddEvent;
            _serviceEvents.RemoveEvent += _serviceEvents_RemoveEvent;
            _serviceEvents.UpdateEvent += _serviceEvents_UpdateEvent;
        }

        private void _serviceEvents_UpdateEvent(Guid uid, WorkerModel model)
        {
            IComponentOrganization component = _tree.Search(uid);

            if (component == default) return;

            IComponentOrganization componentToUpdate = WorkerConverter.CreateComponent(model, component.ParantComponent as BaseDivision);
            component.ParantComponent.Remove(component);
            component.ParantComponent.Add(componentToUpdate);
        }

        private void _serviceEvents_RemoveEvent(Guid uid)
        {
            IComponentOrganization component = _tree.Search(uid);

            if (component == default) return;

            component.ParantComponent.Remove(component);
        }

        private void _serviceEvents_AddEvent(WorkerModel model)
        {
            IComponentOrganization parantComponent = _tree.Search(model.Department);

            if (parantComponent == default) return;

            parantComponent.Add(WorkerConverter.CreateComponent(model, parantComponent as BaseDivision));
        }
    }
}
