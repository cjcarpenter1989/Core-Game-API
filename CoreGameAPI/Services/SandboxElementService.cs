using CoreGameAPI.Data;
using CoreGameAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGameAPI.Services
{
    public class SandboxElementService : ISandboxElementService
    {
        private readonly SandboxContext _dbContext = null;
        public SandboxElementService(SandboxContext sandboxContext)
        {
            _dbContext = sandboxContext;
        }
        public async Task<List<SandboxElement>> GetAllSandboxElements()
        {
            return await _dbContext.SandboxElements.Include(x => x.SandboxElementStyle).ToListAsync();
        }
    }
}
