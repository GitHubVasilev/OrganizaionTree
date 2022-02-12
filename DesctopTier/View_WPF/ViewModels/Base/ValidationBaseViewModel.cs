using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace View_WPF.ViewModels.Base
{
    public class ValidationBaseViewModel : BaseViewModel, INotifyDataErrorInfo
    {
        private Dictionary<string, List<string>> _errors = new();

        public bool HasErrors => _errors.Count > 0;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged = delegate { };

        public IEnumerable GetErrors(string propertyName)
        {
            return _errors.ContainsKey(propertyName) ? _errors[propertyName] : null;
        }

        public override bool Set<T>(ref T field, T val, [CallerMemberName] string propertyName = "")
        {
            if (!base.Set(ref field, val, propertyName)) { return false; }
            ValidateProperty(propertyName, val);
            return true;
        }

        private void ValidateProperty<T>(string propertyName, T value)
        {
            List<ValidationResult> results = new();

            ValidationContext context = new ValidationContext(this);
            context.MemberName = propertyName;
            _ = Validator.TryValidateProperty(value, context, results);

            if (results.Any())
            {
                _errors[propertyName] = results.Select(c => c.ErrorMessage).ToList();
            }
            else
            {
                _errors.Remove(propertyName);
            }

            ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
