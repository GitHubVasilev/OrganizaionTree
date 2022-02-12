using System.Windows;

namespace View_WPF.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для CreateDivisionProperty.xaml
    /// </summary>
    public partial class CreateDivisionWindow : Window
    {
        public CreateDivisionWindow()
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
