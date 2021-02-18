using System.Collections.Generic;
using System.Threading.Tasks;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Domain;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Enum;

namespace Bomtrato.ProcessManager.App.WebAPI.Domain.Interfaces.Repositories
{
    public interface IProcessRepository : IRepository<ProcessDomain>
    {
         Task<ProcessDomain> Get(string number);         
         Task<List<ProcessDomain>> GetByOfficeName(string name);
         Task<List<ProcessDomain>> GetByOfficeName(string name, ProcessActive processActive);
         Task<List<ProcessDomain>> GetByOfficeName(string name, ProcessApproved processApproved);
         Task<List<ProcessDomain>> GetByOfficeName(string name, ProcessActive processActive, ProcessApproved processApproved);
         Task<List<ProcessDomain>> GetByComplainingName(string name);
        Task<List<ProcessDomain>> GetByComplainingName(string name, ProcessActive processActive);
        Task<List<ProcessDomain>> GetByComplainingName(string name, ProcessApproved processApproved);
        Task<List<ProcessDomain>> GetByComplainingName(string name, ProcessActive processActive, ProcessApproved processApproved);
        Task<List<ProcessDomain>> GetByActiveApproved(ProcessActive processActive, ProcessApproved processApproved);

        Task<List<ProcessDomain>> GetByActive(ProcessActive processActive);
        Task<List<ProcessDomain>> GetByApproved(ProcessApproved processApproved);

    }
}