using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiceController.Error
{
    public class HttpResponseException : Exception
    {

        public HttpResponseException(List<ValidationResult> validationResult)
        {
            ValidationResult = validationResult;
        }

        public List<ValidationResult> ValidationResult { get; set; }
    }
}
