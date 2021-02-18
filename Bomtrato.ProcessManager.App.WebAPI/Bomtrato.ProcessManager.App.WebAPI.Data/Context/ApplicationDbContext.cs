using Bomtrato.ProcessManager.App.WebAPI.Data.Map;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bomtrato.ProcessManager.App.WebAPI.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            
        }

        public DbSet<ApproverDomain> Approver { get; set; }
        public DbSet<OfficeDomain> Office { get; set; }
        public DbSet<ProcessDomain> Process { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ApproverMap());
            modelBuilder.ApplyConfiguration(new OfficeMap());
            modelBuilder.ApplyConfiguration(new ProcessMap());        
        }
    }
}