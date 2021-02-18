using System.Threading.Tasks;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Domain;

namespace Bomtrato.ProcessManager.App.WebAPI.Domain.Interfaces.Repositories
{
    public interface IApproverRepository : IRepository<ApproverDomain>
    {
        Task<ApproverDomain> Auth(ApproverDomain approverDomain);
    }
}