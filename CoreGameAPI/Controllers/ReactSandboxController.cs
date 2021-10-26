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
        [HttpGet("GetAllSandboxElements")]
        public async Task<List<SandboxElementViewModel>> GetAllSandboxElements()
        {
            List<SandboxElement> sandboxElements = await _sandboxElementService.GetAllSandboxElements();
            List<SandboxElementViewModel> defaultElements = sandboxElements.Select(x => new SandboxElementViewModel { Key = x.SandboxElementKey, Style = new SandboxElementStyleViewModel { Color = x?.SandboxElementStyle?.Color } }).ToList();
            return defaultElements;
        }


        [HttpGet("Get/{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ReactSandboxController>
        [HttpPost("CreateSandboxElement")]
        public async Task<SandboxElementViewModel> CreateSandboxElement([FromBody] SandboxElementViewModel value)
        {
            SandboxElement sandboxElement = await _sandboxElementService.CreateSandboxElement(value);
            return new SandboxElementViewModel { Key = sandboxElement.SandboxElementKey, Style = new SandboxElementStyleViewModel { Color = sandboxElement?.SandboxElementStyle?.Color } };
        }

        // PUT api/<ReactSandboxController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReactSandboxController>/5
        [HttpDelete("DeleteSandboxElement/{key}")]
        public async Task DeleteSandboxElement(int key)
        {
            await _sandboxElementService.DeleteSandboxElement(key);
        }
    }
}
