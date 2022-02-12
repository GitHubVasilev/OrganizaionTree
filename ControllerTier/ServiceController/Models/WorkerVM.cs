using ConnectToDataLibrary.Models;
using ServiceController.Error;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiceController.Models
{
    public class WorkerVM : AbstractValidateModel
    {
        private readonly WorkerModel _model;

        public WorkerVM(WorkerModel model = null)
        {
            _model = model ?? new();
        }

        public WorkerModel GetBaseModel() => _model; 

        public Guid UID 
        {
            get => _model.UID;
            set => _model.UID = value; 
        }

        public TypeComponent TypeComponent
        {
            get => (TypeComponent)_model.TypeModel;
            set => _model.TypeModel = (int)value; 
        }

        public string Firstname 
        {
            get => _model.Firstname;
            set => _model.Firstname = value; 
        }

        public string Lastname 
        {
            get => _model.Lastname; 
            set => _model.Lastname = value;
        }

        public DateTime Birthday
        {
            get => _model.Birthday;
            set => _model.Birthday = value;
        }

        public decimal PaymentRate
        {
            get => _model.PaymentRate;
            set => _model.PaymentRate = value;
        }

        public Guid Department 
        {
            get => _model.Department;
            set => _model.Department = value;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (!Enum.IsDefined(typeof(TypeComponent), TypeComponent)) 
            {
                errors.Add(new ValidationResult("Не верный тип подразделения", new List<string> { $"{nameof(Firstname)}" }));
            }

            if (string.IsNullOrEmpty(Firstname)) 
            {
                errors.Add(new ValidationResult("Поле имени не должно быть пустым", new List<string> { $"{nameof(Firstname)}" }));
            }

            if (string.IsNullOrEmpty(Lastname))
            {
                errors.Add(new ValidationResult("Поле фамилии не должно быть пустым", new List<string> { $"{nameof(Lastname)}" }));
            }

            if ((Birthday.Year < DateTime.Now.Year - 65) || (Birthday.Year > DateTime.Now.Year - 18))
            {
                errors.Add(new ValidationResult("Возраст должен быть больше 18 но меньше 65", new List<string> { $"{nameof(Birthday)}" }));
            }

            if (PaymentRate <= 0) 
            {
                errors.Add(new ValidationResult("Оклад должен быть больше 0", new List<string> { $"{nameof(PaymentRate)}" }));
            }

            return errors;
        }
    }
}
