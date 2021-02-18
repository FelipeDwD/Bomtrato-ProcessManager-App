using System.Threading.Tasks;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Domain;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Interfaces.Repositories;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Interfaces.Services;

namespace Bomtrato.ProcessManager.App.WebAPI.Service.Services
{
    public class OfficeService : BaseService<OfficeDomain>, IOfficeService
    {
        private readonly IOfficeRepository _officeRepository;
        public OfficeService(IOfficeRepository officeRepository)   
        : base(officeRepository)
        {
            _officeRepository = officeRepository;
        }       

        public async Task<OfficeDomain> GetByName(string name)
        {
            var response = await _officeRepository.GetByName(name);
            return response;
        }
    }
}