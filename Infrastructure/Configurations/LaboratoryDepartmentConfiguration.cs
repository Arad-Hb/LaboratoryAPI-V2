using DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureEfPersistance.Configurations
{
    public class LaboratoryDepartmentConfiguration : IEntityTypeConfiguration<LaboratoryDepartment>
    {
        public void Configure(EntityTypeBuilder<LaboratoryDepartment> builder)
        {
            builder.ToTable("LaboratoryDepartments", "dbo");
            builder.HasKey(d => d.LaboratoryDepartmentId);
            builder.Property(d => d.Code).HasMaxLength(30).IsUnicode(false).IsRequired();
            builder.Property(d => d.Name).HasMaxLength(100).IsUnicode(true).IsRequired();
            builder.Property(d => d.IsActive).HasDefaultValue(true);

            builder.HasIndex(d => d.Code).IsUnique();
        }

    }
}
