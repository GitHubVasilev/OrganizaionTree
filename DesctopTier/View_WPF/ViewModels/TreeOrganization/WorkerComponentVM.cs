using ConnectToControllerTier.Models;
using ConnectToControllerTier.Models.TreeDTO;
using System;
using View_WPF.Interfaces;
using View_WPF.ViewModels.Base;

namespace View_WPF.ViewModels.TreeOrganization
{
    public class WorkerComponentVM : BaseViewModel, IComponentVM
    {
        private WorkerComponent _model;

        public WorkerComponentVM(WorkerComponent model = null)
        {
            _model = model ?? new();
        }
        public WorkerComponent GetBaseModel() => _model;

        public string Name => $"{Firstname} {Lastname}";

        public Guid UID
        {
            get => _model.UID;
            set
            {
                _model.UID = value;
                OnPropertyChanged(nameof(UID));
            }
        }

        public int TypeComponent
        {
            get => (int)_model.TypeComponent;
            set
            {
                _model.TypeComponent = (TypeWorker)value;
                OnPropertyChanged(nameof(TypeComponent));
            }
        }

        public string Firstname
        {
            get => _model.Firstname;
            set 
            {
                _model.Firstname = value;
                OnPropertyChanged(nameof(Firstname));
            }
        }

        public string Lastname
        {
            get => _model.Lastname;
            set
            {
                _model.Lastname = value;
                OnPropertyChanged(nameof(Lastname));
            }
        }

        public DateTime Birthday
        {
            get => _model.Birthday;
            set
            {
                _model.Birthday = value;
                OnPropertyChanged(nameof(Birthday));
            }
        }

        public decimal PaymentRate
        {
            get => _model.PaymentRate;
            set
            {
                _model.PaymentRate = value;
                OnPropertyChanged(nameof(PaymentRate));
            }
        }

        public decimal Salary 
        {
            get => _model.Salary;
            set 
            {
                _model.Salary = value;
                OnPropertyChanged(nameof(Salary));
            }
        }

        public bool IsComposite => false;
    }
}
