using System.Threading.Tasks;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Domain;

namespace Bomtrato.ProcessManager.App.WebAPI.Domain.Interfaces.Repositories
{
    public interface IOfficeRepository : IRepository<OfficeDomain>
    {
       Task<OfficeDomain> GetByName(string name);
    }
}