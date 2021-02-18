using Bomtrato.ProcessManager.App.WebAPI.Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bomtrato.ProcessManager.App.WebAPI.Data.Map
{
    public class ProcessMap : IEntityTypeConfiguration<ProcessDomain>
    {
        public void Configure(EntityTypeBuilder<ProcessDomain> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                  .Property(x => x.Number)
                  .IsRequired()
                  .HasMaxLength(12);

            builder
                  .Property(x => x.CasueValue)
                  .IsRequired();

            builder
                 .HasOne(x => x.Office)
                 .WithMany(y => y.Processes)
                 .HasForeignKey(x => x.IdOffice);

            builder
                 .Property(x => x.ComplainingName)
                 .IsRequired()
                 .HasMaxLength(100);

            builder
                .Property(x => x.Active)
                .IsRequired();

            builder 
                .Property(x => x.Approved)
                .IsRequired();

            builder.ToTable("Process");                                                 
        }
    }
}