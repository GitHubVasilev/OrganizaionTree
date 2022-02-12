using ConnectToControllerTier.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View_WPF.Interfaces
{
    public interface IDialogs
    {
        IDialog GetDialogPropertyWorker();
        IDialog GetDialogPropertyDivision();
        IDialog GetDialogCreateDivision();
        IDialog GetDialogCreateWorker();
    }
}
