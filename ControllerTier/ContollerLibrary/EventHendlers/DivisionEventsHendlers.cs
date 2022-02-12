using ConnectToDataLibrary.Interfaces;
using ConnectToDataLibrary.Models;
using ContollerLibrary.Infrastructure;
using ContollerLibrary.Interfaces;
using ControllerLibrary.Models.Divisions;
using System;


namespace ContollerLibrary.EventHendlers
{
    class DivisionEventsHendlers
    {
        private readonly IServiceEvents<DivisionModel> _serviceEvents;
        private readonly ITree _tree;

        public DivisionEventsHendlers(IServiceEvents<DivisionModel> serviceEvents, ITree tree)
        {
            this._tree = tree;
            this._serviceEvents = serviceEvents;

            _serviceEvents.AddEvent += _serviceEvents_AddEvent;
            _serviceEvents.RemoveEvent += _serviceEvents_RemoveEvent;
            _serviceEvents.UpdateEvent += _serviceEvents_UpdateEvent;
        }

        private void _serviceEvents_UpdateEvent(Guid uid, DivisionModel model)
        {
            BaseDivision component = _tree.Search(uid) as BaseDivision;

            if (component == default) return;

            BaseDivision componentToUpdate = DivisionConverter.CreateComponent(model, component.ParantComponent as BaseDivision);
            componentToUpdate.ComponentsOrganization = component.ComponentsOrganization;
            component.ParantComponent.Remove(component);
            component.ParantComponent.Add(componentToUpdate);
        }

        private void _serviceEvents_RemoveEvent(Guid uid)
        {
            IComponentOrganization component = _tree.Search(uid);

            if (component == default) return;

            component.ParantComponent.Remove(component);
        }

        private void _serviceEvents_AddEvent(DivisionModel model)
        {
            IComponentOrganization parantComponent = _tree.Search(model.UIDParant);

            if (parantComponent == default) return;

            parantComponent.Add(DivisionConverter.CreateComponent(model, parantComponent as BaseDivision));
        }
    }
}
