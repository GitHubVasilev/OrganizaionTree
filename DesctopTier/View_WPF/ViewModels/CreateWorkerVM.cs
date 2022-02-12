using ConnectToControllerTier.Errors;
using ConnectToControllerTier.Interfaces;
using ConnectToControllerTier.Models;
using System;
using System.Text;
using System.Windows;
using View_WPF.Infrastructure;
using View_WPF.ViewModels.Base;
using View_WPF.ViewModels.DTOVM;

namespace View_WPF.ViewModels
{
    public class CreateWorkerVM : BaseViewModel
    {

        private readonly IServiceWorkers _serviceWorkers;

        public CreateWorkerVM(IServiceWorkers serviceWorkers)
        {
            _serviceWorkers = serviceWorkers;
            WorkerViewModel = new();
        }

        private WorkerVM _workerVM;

        public WorkerVM WorkerViewModel 
        {
            get => _workerVM;
            set 
            {
                _workerVM = value;
                _workerVM.UID = Guid.NewGuid();
                _workerVM.Birthday = DateTime.Now;
                OnPropertyChanged(nameof(WorkerViewModel));
            }
        }

        private RelayCommand _setUIDParantComponent;

        public RelayCommand SetUIDParantComponent
        {
            get => _setUIDParantComponent ??= new RelayCommand(obj =>
            {
                if (obj == null) 
                {
                    WorkerViewModel.Department = Guid.Empty;
                    return;
                }
                WorkerViewModel.Department = (Guid)obj;
            });
        }

        private RelayCommand _createWorker;

        public RelayCommand CreateWorker 
        {
            get => _createWorker ?? (_createWorker = new RelayCommand(obj =>
            {
                try
                {
                    _serviceWorkers.Create(WorkerViewModel.GetBaseModel());
                }
                catch (HttpResponseException ex)
                {
                    StringBuilder messageError = new();

                    foreach (ErrorModel model in ex.ErrorModels)
                    {
                        messageError.Append($"{model.MemberName} : {model.Message}\n");
                    }

                    MessageBox.Show(messageError.ToString(), ex.GetType().ToString(),  MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }, _ => !WorkerViewModel.HasErrors));
        }
    }
}
