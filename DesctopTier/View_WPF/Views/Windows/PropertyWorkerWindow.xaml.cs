using System.Windows;

namespace View_WPF.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для PropertyWorkerWindow.xaml
    /// </summary>
    public partial class PropertyWorkerWindow : Window
    {
        public PropertyWorkerWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
