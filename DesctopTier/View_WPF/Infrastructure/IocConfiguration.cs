using ConnectToControllerTier.Interfaces;
using ConnectToControllerTier.Services;
using Ninject.Modules;
using View_WPF.Interfaces;
using View_WPF.ViewModels;

namespace View_WPF.Infrastructure
{
    class IocConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<IServiceOrganization>().To<ServiceOrganization>();
            Bind<IServiceDivisions>().To<ServiceDivisions>();
            Bind<IServiceWorkers>().To<ServiceWorkers>();
            Bind<IDialogs>().To<Dialogs>();
            Bind<MainWindowViewModel>().ToSelf();
            Bind<PropertyWorkerVM>().ToSelf();
            Bind<PropertyDivisionVM>().ToSelf();
            Bind<CreateDivisionVM>().ToSelf();
            Bind<CreateWorkerVM>().ToSelf();
        }
    }
}
