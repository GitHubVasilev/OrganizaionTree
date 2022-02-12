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
    public class DivisionsController : ControllerBase
    {
        private readonly IRepository<DivisionModel> _repository;

        public DivisionsController(IRepository<DivisionModel> repository)
        {
            _repository = repository;
        }

        // GET: api/<DivisionsController>
        [HttpGet]
        public IEnumerable<DivisionModel> Get()
        {
            return _repository.GetAll();
        }

        // GET api/<DivisionsController>/5
        [HttpGet("{uid}")]
        public DivisionModel Get(Guid uid)
        {
            return _repository.Get(uid);
        }

        // POST api/<DivisionsController>
        [HttpPost]
        public void Post([FromBody] DivisionModel value)
        {
            _repository.Create(value);
        }

        // PUT api/<DivisionsController>/5
        [HttpPut("{uid}")]
        public void Put(Guid uid, [FromBody] DivisionModel value)
        {
            _repository.Update(uid ,value);
        }

        // DELETE api/<DivisionsController>/5
        [HttpDelete("{uid}")]
        public void Delete(Guid uid)
        {
            _repository.Delete(uid);
        }
    }
}
