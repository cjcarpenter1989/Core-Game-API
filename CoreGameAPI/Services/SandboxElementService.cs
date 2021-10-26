using CoreGameAPI.Data;
using CoreGameAPI.Models;
using CoreGameAPI.ViewModels;
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
        public async Task<SandboxElement> CreateSandboxElement(SandboxElementViewModel sandboxElementViewModel)
        {
            SandboxElement sandboxElement = new SandboxElement();

            sandboxElement.SandboxElementStyle = new SandboxElementStyle { Color = sandboxElementViewModel?.Style.Color };

            await _dbContext.AddAsync(sandboxElement);
            await _dbContext.SaveChangesAsync();

            return sandboxElement;
        }
        public async Task DeleteSandboxElement(int key)
        {
            SandboxElement sandboxElement = await _dbContext.SandboxElements.FirstAsync(x => x.SandboxElementKey == key);

            if (sandboxElement == null)
            {
                throw new Exception("Sandbox element does not exist");
            }

            _dbContext.SandboxElements.Remove(sandboxElement);
            await _dbContext.SaveChangesAsync();
        }
    }
}
