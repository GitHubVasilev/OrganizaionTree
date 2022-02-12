using ConnectToControllerTier.Models;
using System;
using System.ComponentModel.DataAnnotations;
using View_WPF.ViewModels.Base;
using View_WPF.ViewModels.Validation;

namespace View_WPF.ViewModels.DTOVM
{
    public class WorkerVM : ValidationBaseViewModel
    {
        public WorkerVM(WorkerDTO model = null)
        {
            WorkerDTO _model = model ?? new();
            UID = _model.UID;
            Firstname = _model.Firstname;
            Lastname = _model.Lastname;
            Department = _model.Department;
            Birthday = _model.Birthday;
            PaymentRate = _model.PaymentRate;
            TypeComponent = (int)_model.TypeComponent;
        }

        public WorkerDTO GetBaseModel()
        {
            return new WorkerDTO()
            {
                UID = UID,
                Firstname = Firstname,
                Lastname = Lastname,
                TypeComponent = (TypeWorker)TypeComponent,
                Birthday = Birthday,
                PaymentRate = PaymentRate,
                Department = Department
            };
        }


        private Guid _uid;
        public Guid UID
        {
            get => _uid;
            set => Set(ref _uid, value);
        }

        private int _typeComponent;
        public int TypeComponent
        {
            get => _typeComponent;
            set => Set(ref _typeComponent, value);
        }

        private string _firstname;

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Firstname
        {
            get => _firstname;
            set => Set(ref _firstname, value);
        }

        private string _lastname;

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Lastname
        {
            get => _lastname;
            set => Set(ref _lastname, value);
        }

        private DateTime _birthday;

        [MyAwesomeDateValidation]
        public DateTime Birthday
        {
            get => _birthday;
            set => Set(ref _birthday, value);
        }

        private decimal _paymantRate;

        [Range(10, 10000)]
        public decimal PaymentRate
        {
            get => _paymantRate;
            set => Set(ref _paymantRate, value);
        }

        private Guid _department;

        public Guid Department
        {
            get => _department;
            set => Set(ref _department, value);
        }

    }
}
