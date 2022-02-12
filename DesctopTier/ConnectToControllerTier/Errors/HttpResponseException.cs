using ConnectToControllerTier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectToControllerTier.Errors
{
    public class HttpResponseException : Exception
    {
        public List<ErrorModel> ErrorModels { get; set; }
    }
}
