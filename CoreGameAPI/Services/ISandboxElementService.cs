using CoreGameAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreGameAPI.Services
{
    public interface ISandboxElementService
    {
        Task<List<SandboxElement>> GetAllSandboxElements();
    }
}