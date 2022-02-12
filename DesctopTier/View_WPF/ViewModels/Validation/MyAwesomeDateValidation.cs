using System;
using System.ComponentModel.DataAnnotations;

namespace View_WPF.ViewModels.Validation
{
    internal class MyAwesomeDateValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool parse = DateTime.TryParse(value.ToString(), out DateTime date);

            if (!parse) { return false; }

            DateTime minDate = new((DateTime.Now - new DateTime(65, 1, 1)).Ticks);
            DateTime maxDate = DateTime.Now;

            return date < maxDate && date > minDate;
        }
    }
}
