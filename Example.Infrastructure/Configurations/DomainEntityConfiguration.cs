using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Infrastructure.Configurations;

public class DomainEntityConfiguration : IEntityTypeConfiguration<DomainEntity>
{
    public void Configure(EntityTypeBuilder<DomainEntity> builder)
    {
        builder
            .HasKey(p => p.Id);
        builder
            .Property(p => p.Id)
            .UseIdentityColumn()
            .ValueGeneratedOnAdd();
        builder
            .Property(p => p.Name)
            .HasMaxLength(255);
    }
}
