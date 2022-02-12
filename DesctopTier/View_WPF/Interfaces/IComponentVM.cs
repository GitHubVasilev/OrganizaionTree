using ConnectToControllerTier.Models;
using System;

namespace View_WPF.Interfaces
{
    public interface IComponentVM
    {
        Guid UID { get; set; }
        string Name { get; }
        bool IsComposite { get; }
    }
}
