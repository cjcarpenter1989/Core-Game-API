using CoreGameAPI.Models;
using CoreGameAPI.Services;
using CoreGameAPI.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class ReactSandboxController : ControllerBase
    {
        private readonly ISandboxElementService _sandboxElementService = null;
        public ReactSandboxController(ISandboxElementService sandboxElementService)
        {
            _sandboxElementService = sandboxElementService;
        }

        // GET: api/<ReactSandboxController>
        [HttpGet]
        public async Task<List<SandboxElementViewModel>> Get()
        {
            List<SandboxElement> sandboxElements = await _sandboxElementService.GetAllSandboxElements();
            List<SandboxElementViewModel> defaultElements = sandboxElements.Select(x => new SandboxElementViewModel { Key = x.SandboxElementKey, Style = new SandboxElementStyleViewModel { Color = x?.SandboxElementStyle?.Color } }).ToList();
            return defaultElements;
        }

        // GET api/<ReactSandboxController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ReactSandboxController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ReactSandboxController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReactSandboxController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
