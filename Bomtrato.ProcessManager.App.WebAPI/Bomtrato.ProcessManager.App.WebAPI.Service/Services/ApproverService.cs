using System.Threading.Tasks;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Domain;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Interfaces.Repositories;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Interfaces.Services;

namespace Bomtrato.ProcessManager.App.WebAPI.Service.Services
{
   public class ApproverService : BaseService<ApproverDomain>, IApproverService
    {
        private readonly IApproverRepository _approverRepository;
        public ApproverService(IApproverRepository approverRepository)
        : base(approverRepository)
        {
            _approverRepository = approverRepository;
        }

        public async Task<ApproverDomain> Auth(ApproverDomain approverDomain)
        {
            var response = await _approverRepository.Auth(approverDomain);
            return response;
        }
    }
}