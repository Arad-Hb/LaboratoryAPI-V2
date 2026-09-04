using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfrastructureEfPersistance.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("AspNetUsers");
        builder.Property(u => u.FullName)
            .HasMaxLength(150)
            .IsUnicode(true)
            .HasDefaultValue(string.Empty);
    }
}
