using System.Collections.Generic;
using System.Threading.Tasks;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Domain;

namespace Bomtrato.ProcessManager.App.WebAPI.Domain.Interfaces.Services
{
    public interface IProcessService : IBaseService<ProcessDomain>
    {
        Task<ProcessDomain> Get(string number);
        Task<List<ProcessDomain>> Filter(string filter, int active, int approved);
    }
}