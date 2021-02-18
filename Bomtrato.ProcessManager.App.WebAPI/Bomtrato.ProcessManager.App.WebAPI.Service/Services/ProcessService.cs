using System.Collections.Generic;
using System.Threading.Tasks;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Domain;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Enum;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Interfaces.Repositories;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Interfaces.Services;

namespace Bomtrato.ProcessManager.App.WebAPI.Service.Services
{
    public class ProcessService : BaseService<ProcessDomain>, IProcessService
    {
       private readonly IProcessRepository _processRepository;
       public ProcessService(IProcessRepository processRepository)
       : base(processRepository)
       {
           _processRepository = processRepository;
       }

        public async Task<List<ProcessDomain>> Filter(string filter, int active, int approved)
        {
            ProcessActive processActive = (ProcessActive)active;
            ProcessApproved processApproved = (ProcessApproved)approved;

            filter = (filter != "null" && filter != "undefined") ? filter : null;
            bool onlyFilter = FilterText(active, approved);

           if (filter == null && onlyFilter)
                return await GetAll();           


            List<ProcessDomain> response = new List<ProcessDomain>();
            ProcessDomain item = null;           

           if (filter == null && processApproved == ProcessApproved.All)
                return await _processRepository.GetByActive(processActive);

            if (filter == null && processActive == ProcessActive.All)
                return await _processRepository.GetByApproved(processApproved);

            if (filter == null)
                return await _processRepository.GetByActiveApproved(processActive, processApproved);          

            if (onlyFilter)
            {
                item = await _processRepository.Get(filter);

                if (item != null)
                    return new List<ProcessDomain> { item };

                response = await _processRepository.GetByOfficeName(filter);

                if (response.Count != 0)
                    return response;
                else
                    return await _processRepository.GetByComplainingName(filter);
            }
            else if (FilterActive(active, approved))
            {
                response = await _processRepository.GetByOfficeName(filter, processActive);

                if (response.Count != 0)
                    return response;

                return await _processRepository.GetByComplainingName(filter, processActive);

            }
            else if (FilterApproved(active, approved))
            {
                response = await _processRepository.GetByOfficeName(filter, processApproved);

                if (response.Count != 0)
                    return response;

                return await _processRepository.GetByComplainingName(filter, processApproved);
            }

            response = await _processRepository.GetByOfficeName(filter, processActive, processApproved);

            if (response.Count != 0)
                return response;

            response = await _processRepository.GetByComplainingName(filter, processActive, processApproved);

            if (response.Count != 0)
                return response;

            item =  await Get(filter);

            return new List<ProcessDomain> { item };
        }

        public async Task<ProcessDomain> Get(string number)
        {
            var item = await _processRepository.Get(number);
            return item;
        }

        private bool FilterText(int active, int approved)
               => active == (int)ProcessActive.All
                  && approved == (int)ProcessApproved.All;

        private bool FilterActive(int active, int approved)
            => active != (int)ProcessActive.All
               && approved == (int)ProcessApproved.All;

        private bool FilterApproved(int active, int approved)
            => active == (int)ProcessActive.All
               && approved != (int)ProcessApproved.All;     
        
    }
}