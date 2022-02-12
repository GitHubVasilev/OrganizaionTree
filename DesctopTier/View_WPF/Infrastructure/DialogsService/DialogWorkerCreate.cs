using View_WPF.Interfaces;
using View_WPF.Views.Windows;

namespace View_WPF.Infrastructure.DialogsService
{
    public class DialogWorkerCreate : IDialog
    {
        private CreateWorkerWindow _window;

        public DialogWorkerCreate()
        {
            _window = new();
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
