using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceController.Error
{
    public enum EnumError 
    {
        ErrorName,
        ErrorLastname,
        ErrorType,
        ErrorBirthday,
        ErrorPaymentRate
    }

    public class ErrorModel
    {
        public string MemberName { get; set; }
        public string Message { get; set; }
    }
}
