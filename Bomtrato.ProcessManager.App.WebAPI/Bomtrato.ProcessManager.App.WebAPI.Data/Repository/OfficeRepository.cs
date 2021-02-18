using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bomtrato.ProcessManager.App.WebAPI.Data.Context;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Domain;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bomtrato.ProcessManager.App.WebAPI.Data.Repository
{
    public class OfficeRepository : Repository<OfficeDomain>, IOfficeRepository
    {
        public OfficeRepository(ApplicationDbContext dbContext)
        : base(dbContext)
        {
            
        }

        public override async Task<List<OfficeDomain>> GetAll()
        {
            var items = await DbSet.ToListAsync();
            
            var response = items
                            .OrderBy(x => x.Name)
                            .ToList();

            return response;                            
        }

        public async Task<OfficeDomain> GetByName(string name)
        {
            var response = await DbSet.FirstOrDefaultAsync(x => x.Name == name);
            return response;
        }
    }
}