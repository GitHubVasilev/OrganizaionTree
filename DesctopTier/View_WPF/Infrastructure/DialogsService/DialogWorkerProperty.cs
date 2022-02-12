using View_WPF.Interfaces;
using View_WPF.Views.Windows;

namespace View_WPF.Infrastructure.DialogsService
{
    public class DialogWorkerProperty : IDialog
    {
        private PropertyWorkerWindow _window;

        public DialogWorkerProperty()
        {
            _window = new PropertyWorkerWindow();
        }

        public bool ResultDialog
        {
            get => _window.DialogResult ?? false;
        }

        public void OpenWindow() 
        {
            _window.ShowDialog();
        }
    }
}
