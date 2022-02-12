using DataLibrary.Interfaces;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServiceData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly IRepository<WorkerModel> _repository;

        public WorkersController(IRepository<WorkerModel> repository)
        {
            _repository = repository;
        }

        // GET: api/<WorkersController>
        [HttpGet]
        public IEnumerable<WorkerModel> Get()
        {
            return _repository.GetAll();
        }

        // GET api/<WorkersController>/5
        [HttpGet("{uid}")]
        public WorkerModel Get(Guid uid)
        {
            return _repository.Get(uid);
        }

        // POST api/<WorkersController>
        [HttpPost]
        public void Post([FromBody] WorkerModel value)
        {
            _repository.Create(value);
        }

        // PUT api/<WorkersController>/5
        [HttpPut("{uid}")]
        public void Put(Guid uid, [FromBody] WorkerModel value)
        {
            _repository.Update(uid, value);
        }

        // DELETE api/<WorkersController>/5
        [HttpDelete("{uid}")]
        public void Delete(Guid uid)
        {
            _repository.Delete(uid);
        }
    }
}
