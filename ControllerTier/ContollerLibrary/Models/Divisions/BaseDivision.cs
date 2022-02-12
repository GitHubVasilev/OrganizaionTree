using ConnectToDataLibrary.Models;
using ContollerLibrary.Interfaces;
using System;
using System.Collections.Generic;

namespace ControllerLibrary.Models.Divisions
{
    public abstract class BaseDivision : IComponentOrganization
    {
        public BaseDivision()
        {
            UID = new Guid();
            ComponentsOrganization = new List<IComponentOrganization>();
        }

        public Guid UID { get; set; }
        public string Name { get; set; }
        public IComponentOrganization ParantComponent { get; set; }
        public List<IComponentOrganization> ComponentsOrganization { get; set; }

        public TypeComponent TypeComponent { get; protected set; }

        public bool IsComposite => true;

        public void Add(IComponentOrganization component)
        {
            ComponentsOrganization.Add(component);
        }

        public void Remove(IComponentOrganization component)
        {
            ComponentsOrganization.Remove(component);
        }
    }
}
