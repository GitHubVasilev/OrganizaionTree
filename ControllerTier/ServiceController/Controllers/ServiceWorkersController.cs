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
    public class ServiceWorkersController : ControllerBase
    {
        private readonly IService<WorkerModel> _service;

        public ServiceWorkersController(IService<WorkerModel> service)
        {
            this._service = service;
        }

        // GET: api/<ServiceWorkersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ServiceWorkersController>/5
        [HttpGet("{uid}")]
        public WorkerVM Get(Guid uid)
        {
            return new WorkerVM(_service.Get(uid));
        }

        // POST api/<ServiceWorkersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            WorkerVM model = JsonConvert.DeserializeObject<WorkerVM>(value);

            if (!model.IsValid())
            {
                ValidationContext context = new ValidationContext(model);
                var errors = new List<ValidationResult>(model.Validate(context));
                throw new HttpResponseException(errors);
            }

            _service.Set(JsonConvert.DeserializeObject<WorkerVM>(value).GetBaseModel());
        }

        // PUT api/<ServiceWorkersController>/5
        [HttpPut("{uid}")]
        public void Put(Guid uid, [FromBody] string value)
        {
            WorkerVM model = JsonConvert.DeserializeObject<WorkerVM>(value);

            if (!model.IsValid())
            {
                ValidationContext context = new ValidationContext(model);
                throw new HttpResponseException(new List<ValidationResult>(model.Validate(context)));
            }

            _service.Update(uid, model.GetBaseModel());
        }

        // DELETE api/<ServiceWorkersController>/5
        [HttpDelete("{uid}")]
        public void Delete(Guid uid)
        {
            _service.Delete(uid);
        }
    }
}
