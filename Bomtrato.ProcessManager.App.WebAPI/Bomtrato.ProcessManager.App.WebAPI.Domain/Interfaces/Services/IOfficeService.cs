using System.Collections.Generic;
using System.Threading.Tasks;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Domain;

namespace Bomtrato.ProcessManager.App.WebAPI.Domain.Interfaces.Services
{
   public interface IOfficeService 
    {
         Task<bool> Add(OfficeDomain office);
         Task<OfficeDomain> GetByName(string name);

         Task<List<OfficeDomain>> GetAll();
    }
}