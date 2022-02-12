using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace View_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            App.LanguageChanged += LanguageChanged;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void tree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            SelectedItemHelper.Content = e.NewValue;
        }

        private void LanguageChanged(object sender, EventArgs e)
        {
            CultureInfo currLang = App.Language;
            
            //Отмечаем нужный пункт смены языка как выбранный язык
            foreach (MenuItem i in menuLanguage.Items)
            {
                CultureInfo ci = i.Tag as CultureInfo;
                i.IsChecked = ci != null && ci.Equals(currLang);
            }
            DataGridSelectedItemInTree.Items.Refresh();
        }

        private void ChangeLanguageClick(object sender, EventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            if (mi != null)
            {
                CultureInfo lang = new CultureInfo(mi.Tag.ToString(), false);
                if (lang != null)
                {
                    App.Language = lang;
                }
            }
        }
    }
}
