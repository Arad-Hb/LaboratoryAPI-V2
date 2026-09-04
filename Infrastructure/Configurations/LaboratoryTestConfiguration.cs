using DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureEfPersistance.Configurations
{
    public class LaboratoryTestConfiguration : IEntityTypeConfiguration<LaboratoryTest>
    {
        public void Configure(EntityTypeBuilder<LaboratoryTest> builder)
        {
            builder.ToTable("LaboratoryTests", "dbo");
            builder.HasKey(t => t.LaboratoryTestId);
            builder.Property(t => t.Code).HasMaxLength(30).IsUnicode(false).IsRequired();
            builder.Property(t => t.Name).HasMaxLength(150).IsUnicode(true).IsRequired();
            builder.Property(t => t.Unit).HasMaxLength(50).IsUnicode(true).IsRequired(false);
            builder.Property(t => t.IsActive).HasDefaultValue(true);

            builder.HasIndex(t => t.Code).IsUnique();

            builder.HasOne(t => t.LaboratoryDepartment)
                .WithMany(d => d.LaboratoryTests)
                .HasForeignKey(t => t.LaboratoryDepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.SampleType)
                .WithMany(s => s.LaboratoryTests)
                .HasForeignKey(t => t.SampleTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(t => new { t.LaboratoryDepartmentId, t.IsActive });
        }
    }
}
