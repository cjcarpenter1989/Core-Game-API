using CoreGameAPI.Models;
using CoreGameAPI.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreGameAPI.Services
{
    public interface ISandboxElementService
    {
        Task<SandboxElement> CreateSandboxElement(SandboxElementViewModel sandboxElementViewModel);
        Task DeleteSandboxElement(int key);
        Task<List<SandboxElement>> GetAllSandboxElements();
    }
}