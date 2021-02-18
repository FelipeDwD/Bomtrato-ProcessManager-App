using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bomtrato.ProcessManager.App.WebAPI.Data.Context;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Domain;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Enum;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bomtrato.ProcessManager.App.WebAPI.Data.Repository
{
    public class ProcessRepository : Repository<ProcessDomain>, IProcessRepository
    {
        public ProcessRepository(ApplicationDbContext dbContext)
        : base(dbContext)
        {
            
        }

        public async Task<ProcessDomain> Get(string number)
        {
            var response = await DbSet
                                    .Include(x => x.Office)
                                    .FirstOrDefaultAsync(x => x.Number == number);
            return response;
        }

        public override async Task<List<ProcessDomain>> GetAll()
        {
            var response = await DbSet
                                    .Include(x => x.Office)
                                    .ToListAsync();

            return response;                                    
        }

        public async Task<List<ProcessDomain>> GetByActive(ProcessActive processActive)
        {
            var response = await DbSet
                                    .Include(x => x.Office)
                                    .Where(x => x.Active == Convert.ToBoolean(processActive))
                                    .ToListAsync();

            return response;
        }

        public async Task<List<ProcessDomain>> GetByActiveApproved(ProcessActive processActive, ProcessApproved processApproved)
        {
            var response = await DbSet
                                    .Include(x => x.Office)
                                    .Where(x => x.Active == Convert.ToBoolean(processActive) 
                                           && x.Approved == Convert.ToBoolean(processApproved))
                                    .ToListAsync();

            return response;
        }

        public async Task<List<ProcessDomain>> GetByApproved(ProcessApproved processApproved)
        {
            var response = await DbSet
                                    .Include(x => x.Office)
                                    .Where(x => x.Approved == Convert.ToBoolean(processApproved))
                                    .ToListAsync();

            return response;
        }

        public async Task<List<ProcessDomain>> GetByComplainingName(string name)
        {
            var response = await DbSet
                                    .Include(x => x.Office)
                                    .Where(x => x.ComplainingName.Contains(name))
                                    .ToListAsync();

            return response;
        }       

        public async Task<List<ProcessDomain>> GetByComplainingName(string name, ProcessApproved processApproved)
        {
            var response = await DbSet
                                    .Include(x => x.Office)
                                    .Where(x => x.ComplainingName.Contains(name) 
                                           && x.Approved == Convert.ToBoolean(processApproved))
                                    .ToListAsync();
            return response;
        }

        public async Task<List<ProcessDomain>> GetByComplainingName(string name, ProcessActive processActive, ProcessApproved processApproved)
        {
            var response = await DbSet
                                    .Include(x => x.Office)
                                    .Where(x => x.ComplainingName.Contains(name)
                                  && x.Active == Convert.ToBoolean(processActive) 
                                  && x.Approved == Convert.ToBoolean(processApproved))
                                    .ToListAsync();

            return response;
        }

        public async Task<List<ProcessDomain>> GetByComplainingName(string name, ProcessActive processActive)
        {
            var response = await DbSet
                                    .Include(x => x.Office)
                                    .Where(x => x.ComplainingName.Contains(name)
                                           && x.Active == Convert.ToBoolean(processActive))
                                    .ToListAsync();

            return response;
        }

        public async Task<List<ProcessDomain>> GetByOfficeName(string name)
        {
            var response = await DbSet
                                    .Include(x => x.Office)
                                    .Where(x => x.Office.Name.Contains(name))
                                    .ToListAsync();

            return response;
        }

        public async Task<List<ProcessDomain>> GetByOfficeName(string name, ProcessActive processActive)
        {
            var response = await DbSet
                                    .Include(x => x.Office)
                                    .Where(x => x.Office.Name.Contains(name)
                                           && x.Active == Convert.ToBoolean(processActive))
                                    .ToListAsync();

            return response;
        }

        public async Task<List<ProcessDomain>> GetByOfficeName(string name, ProcessApproved processApproved)
        {
            var response = await DbSet
                                    .Include(x => x.Office)
                                    .Where(x => x.Office.Name.Contains(name)
                                           && x.Approved == Convert.ToBoolean(processApproved))
                                    .ToListAsync();

            return response;
        }

        public async Task<List<ProcessDomain>> GetByOfficeName(string name, ProcessActive processActive, ProcessApproved processApproved)
        {
            var response = await DbSet
                                    .Include(x => x.Office)
                                    .Where(x => x.Office.Name.Contains(name)
                                           && x.Active == Convert.ToBoolean(processActive) 
                                           && x.Approved == Convert.ToBoolean(processApproved))
                                    .ToListAsync();

            return response;
        }
    }
}