using ConnectToDataLibrary.Models;
using ServiceController.Error;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiceController.Models
{
    
    public class DivisionVM : AbstractValidateModel
    {
        private readonly DivisionModel _model;

        public DivisionVM(DivisionModel model = null)
        {
            _model = model ?? new DivisionModel();
        }
        
        public DivisionModel GetBaseModel() => _model; 

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

        public string Name
        {
            get => _model.Name;
            set => _model.Name = value;
        }

        public Guid UIDParant 
        {
            get => _model.UIDParant;
            set => _model.UIDParant = value;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (!Enum.IsDefined(typeof(TypeComponent), TypeComponent))
            {
                errors.Add(new ValidationResult("Не верный тип подразделения", new List<string> { $"{nameof(TypeComponent)}" }));
            }

            if (string.IsNullOrEmpty(this.Name)) 
            {
                errors.Add(new ValidationResult("Имя не должно быть пустым", new List<string> { $"{nameof(Name)}" }));
            }

            return errors;
        }
    }
}
