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
    public class PropertyWorkerVM : BaseViewModel
    {
        private readonly IServiceWorkers _serviceWorkers;

        public PropertyWorkerVM(IServiceWorkers service)
        {
            _serviceWorkers = service;
        }

        private WorkerVM _workerVM;

        public WorkerVM WorkerVM
        {
            get => _workerVM ?? new WorkerVM();
            set 
            {
                _workerVM = value;
                OnPropertyChanged(nameof(WorkerVM));
            }
        }

        private RelayCommand _searchAndSetModel;

        public RelayCommand SearchAndSetModel
        {
            get => _searchAndSetModel ?? (_searchAndSetModel = new RelayCommand(obj =>
            {
                WorkerVM = new WorkerVM(_serviceWorkers.Get(new Guid(obj.ToString())));
            }));
        }

        private RelayCommand _update;

        public RelayCommand Update 
        {
            get => _update ?? (_update = new RelayCommand(obj =>
            {
                try
                {
                    _serviceWorkers.Update(WorkerVM.GetBaseModel());
                }
                catch (HttpResponseException ex)
                {
                    StringBuilder messageError = new();

                    foreach (ErrorModel model in ex.ErrorModels)
                    {
                        messageError.Append($"{model.MemberName} : {model.Message}\n");
                    }

                    MessageBox.Show(messageError.ToString(), ex.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }, _ => !WorkerVM.HasErrors));
        }
    }
}
