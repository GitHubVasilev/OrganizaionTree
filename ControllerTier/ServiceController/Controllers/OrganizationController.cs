using ContollerLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ServiceController.Fuctories;
using ServiceController.Models;
using ServiceController.Models.TreeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServiceController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IServiceOrganization _service;
        private readonly OrganizationFactory _factory;

        public OrganizationController(IServiceOrganization service)
        {
            this._service = service;
            _factory = new();
        }
        // GET: api/<OrganizationController>
        [HttpGet]
        public TreeOrganizationDTO Get()
        {
            return _factory.CreateDTO(_service.Organization);
        }

        // GET api/<OrganizationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrganizationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrganizationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrganizationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
