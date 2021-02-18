using Bomtrato.ProcessManager.App.WebAPI.Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bomtrato.ProcessManager.App.WebAPI.Data.Map
{
    public class ApproverMap : IEntityTypeConfiguration<ApproverDomain>
    {
        public void Configure(EntityTypeBuilder<ApproverDomain> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                  .Property(x => x.Email)
                  .IsRequired()
                  .HasMaxLength(60);  

            builder
                  .Property(x => x.Password)
                  .IsRequired()
                  .HasMaxLength(60);  

            
            builder
                  .Property(x => x.Name)
                  .IsRequired()
                  .HasMaxLength(60);   

            builder
                  .Property(x => x.Surname)
                  .IsRequired()
                  .HasMaxLength(60);     

            builder
                  .Property(x => x.OAB)
                  .IsRequired()
                  .HasMaxLength(60);                       

            builder
                  .ToTable("Approver");
        }
    }
}