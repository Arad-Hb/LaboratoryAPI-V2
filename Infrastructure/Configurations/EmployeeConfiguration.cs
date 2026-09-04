using DomainModel.Common;
using DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfrastructureEfPersistance.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees", "dbo");
        builder.HasKey(e => e.EmployeeId);

        builder.Property(e => e.UserId)
            .HasConversion(id => id.Value, value => UserId.From(value))
            .HasMaxLength(450)
            .IsRequired();

        builder.HasIndex(e => e.UserId).IsUnique();

        builder.Property(e => e.AssignedAt)
            .HasColumnType("datetime2(0)")
            .HasDefaultValueSql("SYSUTCDATETIME()");

        builder.Property(e => e.IsActive).HasDefaultValue(true);

        builder.HasOne(e => e.LaboratoryDepartment)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.LaboratoryDepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.AssignedByEmployee)
            .WithMany(e => e.AssignedEmployees)
            .HasForeignKey(e => e.AssignedByEmployeeId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);

        builder.HasOne<ApplicationUser>()
            .WithOne(u => u.Employee)
            .HasForeignKey<Employee>(e => e.UserId)
            .HasPrincipalKey<ApplicationUser>(u => u.Id)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.LaboratoryDepartmentId);
    }
}
