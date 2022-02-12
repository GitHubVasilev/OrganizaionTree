using ConnectToDataLibrary.Models;
using System;

namespace ContollerLibrary.Interfaces
{
    public interface IComponentOrganization
    {
        Guid UID { get; }
        IComponentOrganization ParantComponent { get; set; }
        bool IsComposite { get; }
        TypeComponent TypeComponent { get; }

        void Add(IComponentOrganization component);
        void Remove(IComponentOrganization component);
    }
}
