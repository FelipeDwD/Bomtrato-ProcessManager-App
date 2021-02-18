using System.Threading.Tasks;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Domain;

namespace Bomtrato.ProcessManager.App.WebAPI.Domain.Interfaces.Services
{
    public interface IApproverService : IBaseService<ApproverDomain>
    {
         Task<ApproverDomain> Auth(ApproverDomain approverDomain);
    }
}