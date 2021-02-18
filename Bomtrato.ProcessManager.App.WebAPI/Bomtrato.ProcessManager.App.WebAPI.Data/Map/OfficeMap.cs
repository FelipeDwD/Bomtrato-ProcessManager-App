using Bomtrato.ProcessManager.App.WebAPI.Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bomtrato.ProcessManager.App.WebAPI.Data.Map
{
    public class OfficeMap : IEntityTypeConfiguration<OfficeDomain>
    {
        public void Configure(EntityTypeBuilder<OfficeDomain> builder)
        {
            builder.HasKey(x => x.Id);

            builder 
                 .Property(x => x.Name)
                 .IsRequired()
                 .HasMaxLength(50);                                        

            builder.ToTable("Office");

        }
    }
}