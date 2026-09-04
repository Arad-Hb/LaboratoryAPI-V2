using DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureEfPersistance.Configurations
{
    public class SampleConfiguration : IEntityTypeConfiguration<Sample>
    {
        public void Configure(EntityTypeBuilder<Sample> builder)
        {
            builder.ToTable("Samples", "dbo");
            builder.HasKey(s => s.SampleId);
            builder.Property(s => s.Barcode).HasMaxLength(50).IsUnicode(false).IsRequired();
            builder.Property(s => s.CollectedAtUtc).HasColumnType("datetime2(0)").IsRequired(false);
            builder.Property(s => s.RejectionReason).HasMaxLength(500).IsUnicode(true).IsRequired(false);
            builder.Property(s => s.RowVersion).IsRowVersion();

            builder.HasIndex(s => s.Barcode).IsUnique();

            builder.HasOne(s => s.TestRequest)
                .WithMany(r => r.Samples)
                .HasForeignKey(s => s.TestRequestId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.SampleType)
                .WithMany(st => st.Samples)
                .HasForeignKey(s => s.SampleTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.LaboratoryDepartment)
                .WithMany(d => d.Samples)
                .HasForeignKey(s => s.LaboratoryDepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Status)
                .WithMany(st => st.Samples)
                .HasForeignKey(s => s.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.CollectedByEmployee)
                .WithMany(e => e.Samples)
                .HasForeignKey(s => s.CollectedByEmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(s => new { s.LaboratoryDepartmentId, s.StatusId, s.CollectedAtUtc });
        }
    }
}
