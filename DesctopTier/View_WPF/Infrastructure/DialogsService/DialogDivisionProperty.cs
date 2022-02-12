using View_WPF.Interfaces;
using View_WPF.Views.Windows;

namespace View_WPF.Infrastructure.DialogsService
{
    public class DialogDivisionProperty : IDialog
    {
        private readonly PropertyDivisionWindow _window;

        public DialogDivisionProperty()
        {
            _window = new PropertyDivisionWindow();
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
