using Ninject;
using Ninject.Modules;
using View_WPF.ViewModels;

namespace View_WPF.Infrastructure
{
    public class ViewModelLocator
    {
        
        private StandardKernel _kernal;
        private MainWindowViewModel _mainWindowViewModel;

        public ViewModelLocator()
        {
            NinjectModule registrations = new IocConfiguration();
            _kernal = new StandardKernel(registrations);
            _mainWindowViewModel = _kernal.Get<MainWindowViewModel>();
        }

        public MainWindowViewModel MainViewModel => _mainWindowViewModel;
        public PropertyWorkerVM PropertyWorkerVM => _kernal.Get<PropertyWorkerVM>();
        public PropertyDivisionVM PropertyDivisionVM => _kernal.Get<PropertyDivisionVM>();
        public CreateWorkerVM CreateWorkerVM => _kernal.Get<CreateWorkerVM>();
        public CreateDivisionVM CreateDivisionVM => _kernal.Get<CreateDivisionVM>();
    }
}
