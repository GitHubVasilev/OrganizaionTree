using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ServiceController.Error
{
    public abstract class AbstractValidateModel : IValidatableObject
    {
        public abstract IEnumerable<ValidationResult> Validate(ValidationContext validationContext);

        public bool IsValid() 
        {
            ValidationContext validationContext = new(this);
            List<ValidationResult> result = Validate(validationContext).ToList();

            return Validator.TryValidateObject(this, validationContext, result, false);
        }
    }
}
