using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceController.Error;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServiceController.Controllers
{
    [ApiExplorerSettings(IgnoreApi=true)]
    public class ErrorController : ControllerBase
    {
        // GET: api/Error
        [Route("error")]
        public List<ErrorModel> Get()
        {
            IExceptionHandlerFeature context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            HttpResponseException exception = (HttpResponseException)context?.Error;
            Response.StatusCode = 400;
            List<ErrorModel> result = new();

            foreach (ValidationResult vr in exception.ValidationResult) 
            {
                var gen = vr.MemberNames.GetEnumerator();
                gen.MoveNext();
                result.Add(new ErrorModel() { MemberName = gen.Current, Message = vr.ErrorMessage });
            }

            return result;
        }

    }
}
