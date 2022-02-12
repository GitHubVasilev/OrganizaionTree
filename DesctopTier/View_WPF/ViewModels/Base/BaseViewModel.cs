using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace View_WPF.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public bool HasChanged { get; set; } = false;

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
                HasChanged = true;
            }
        }

        public virtual bool Set<T>(ref T field, T value, [CallerMemberName] string prop = "") 
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(prop);
            HasChanged = true;
            return true;
        }
    }
}
