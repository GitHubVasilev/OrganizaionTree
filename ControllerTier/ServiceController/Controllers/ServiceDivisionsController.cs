using ConnectToDataLibrary.Interfaces;
using ConnectToDataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServiceController.Error;
using ServiceController.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServiceController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceDivisionsController : ControllerBase
    {
        private readonly IService<DivisionModel> _service;

        public ServiceDivisionsController(IService<DivisionModel> service)
        {
            this._service = service;
        }

        // GET: api/<ServiceDivisionController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ServiceDivisionController>/5
        [HttpGet("{uid}")]
        public DivisionVM Get(Guid uid)
        {
            return new DivisionVM(_service.Get(uid));
        }

        // POST api/<ServiceDivisionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            DivisionVM model = JsonConvert.DeserializeObject<DivisionVM>(value);

            if (!model.IsValid())
            {
                ValidationContext context = new ValidationContext(model);
                throw new HttpResponseException(new List<ValidationResult>(model.Validate(context)));
            }

            _service.Set(model.GetBaseModel());
        }

        // PUT api/<ServiceDivisionController>/5
        [HttpPut("{uid}")]
        public void Put(Guid uid, [FromBody] string value)
        {
            DivisionVM model = JsonConvert.DeserializeObject<DivisionVM>(value);

            if (!model.IsValid()) 
            {
                ValidationContext context = new ValidationContext(model);
                throw new HttpResponseException(new List<ValidationResult>(model.Validate(context)));
            }

            _service.Update(uid, model.GetBaseModel());

            
        }

        // DELETE api/<ServiceDivisionController>/5
        [HttpDelete("{uid}")]
        public void Delete(Guid uid)
        {
            _service.Delete(uid);
        }
    }
}
