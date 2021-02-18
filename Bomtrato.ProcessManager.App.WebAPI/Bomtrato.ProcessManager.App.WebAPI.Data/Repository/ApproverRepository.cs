using System.Threading.Tasks;
using Bomtrato.ProcessManager.App.WebAPI.Data.Context;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Domain;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bomtrato.ProcessManager.App.WebAPI.Data.Repository
{
    public class ApproverRepository : Repository<ApproverDomain>, IApproverRepository
    { 
        public ApproverRepository(ApplicationDbContext dbContext)
        : base(dbContext)
        {
            
        }

        public async Task<ApproverDomain> Auth(ApproverDomain approverDomain)
        {
            var response = await DbSet
                                    .FirstOrDefaultAsync(x => x.Email == approverDomain.Email 
                                                            && x.Password == approverDomain.Password);
            return response;
        }
    }
}