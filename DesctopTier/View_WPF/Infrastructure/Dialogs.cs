using ConnectToControllerTier.Interfaces;
using View_WPF.Interfaces;
using View_WPF.ViewModels.TreeOrganization;

namespace View_WPF.Infrastructure
{
    class Dialogs : IDialogs
    {
        public IDialog GetDialogPropertyWorker()
        {
            return new DialogsService.DialogWorkerProperty();
        }

        public IDialog GetDialogPropertyDivision() 
        {
            return new DialogsService.DialogDivisionProperty();
        }

        public IDialog GetDialogCreateDivision() 
        {
            return new DialogsService.DialogDivisionCreate();
        }

        public IDialog GetDialogCreateWorker() 
        {
            return new DialogsService.DialogWorkerCreate();
        }
    }
}
