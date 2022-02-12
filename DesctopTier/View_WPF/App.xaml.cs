using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;

namespace View_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static List<CultureInfo> Languages { get; } = new List<CultureInfo>();

        public App()
        {
            Languages.Clear();
            Languages.Add(new CultureInfo("en-US"));
            Languages.Add(new CultureInfo("ru-RU"));
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, e.Exception.Source, MessageBoxButton.OK, MessageBoxImage.Warning);
            e.Handled = true;
        }

        public static event EventHandler LanguageChanged;

        public static CultureInfo Language
        {
            get => System.Threading.Thread.CurrentThread.CurrentUICulture;
            set
            {
                if (value == null) { throw new ArgumentNullException(nameof(value)); }
                if (value == System.Threading.Thread.CurrentThread.CurrentUICulture) { return; }

                //1. Меняем язык приложения:
                System.Threading.Thread.CurrentThread.CurrentUICulture = value;

                //2. Создаём ResourceDictionary для новой культуры
                ResourceDictionary dict = new();
                dict.Source = value.Name switch
                {
                    "en-US" => new Uri(string.Format(@".\Views\Resources\Globalization\Lang.{0}.xaml", value.Name), UriKind.Relative),
                    _ => new Uri(@".\Views\Resources\Globalization\Lang.ru-RU.xaml", UriKind.Relative),
                };

                //3. Находим старую ResourceDictionary и удаляем его и добавляем новую ResourceDictionary
                ResourceDictionary oldDict = (from d in Current.Resources.MergedDictionaries
                                              where d.Source != null && d.Source.OriginalString.StartsWith(@".\Views\Resources\Globalization\Lang.")
                                              select d).First();
                if (oldDict != null)
                {
                    int ind = Current.Resources.MergedDictionaries.IndexOf(oldDict);
                    Current.Resources.MergedDictionaries.Remove(oldDict);
                    Current.Resources.MergedDictionaries.Insert(ind, dict);
                }
                else
                {
                    Current.Resources.MergedDictionaries.Add(dict);
                }

                //4. Вызываем евент для оповещения всех окон.
                LanguageChanged(Current, new EventArgs());
            }
        }
    }
}
