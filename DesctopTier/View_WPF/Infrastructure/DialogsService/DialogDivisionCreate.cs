using View_WPF.Interfaces;
using View_WPF.Views.Windows;

namespace View_WPF.Infrastructure.DialogsService
{
    public class DialogDivisionCreate : IDialog
    {
        private CreateDivisionWindow _window;

        public DialogDivisionCreate()
        {
            _window = new CreateDivisionWindow();
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
