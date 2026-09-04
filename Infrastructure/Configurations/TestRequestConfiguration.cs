using DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureEfPersistance.Configurations
{
    public class TestRequestConfiguration : IEntityTypeConfiguration<TestRequest>
    {
        public void Configure(EntityTypeBuilder<TestRequest> builder)
        {
            builder.ToTable("TestRequests", "dbo");
            builder.HasKey(r => r.TestRequestId);
            builder.Property(r => r.RequestNumber).HasMaxLength(30).IsUnicode(false).IsRequired();
            builder.Property(r => r.RegisteredAtUtc).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSUTCDATETIME()");
            builder.Property(r => r.CompletedAtUtc).HasColumnType("datetime2(0)").IsRequired(false);
            builder.Property(r => r.RowVersion).IsRowVersion();

            builder.HasIndex(r => r.RequestNumber).IsUnique();

            builder.HasOne(r => r.Patient)
                .WithMany(p => p.TestRequests)
                .HasForeignKey(r => r.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Status)
                .WithMany(s => s.TestRequests)
                .HasForeignKey(r => r.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.RegisteredByEmployee)
                .WithMany(e => e.TestRequests)
                .HasForeignKey(r => r.RegisteredByEmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(r => new { r.PatientId, r.RegisteredAtUtc });
            builder.HasIndex(r => new { r.StatusId, r.RegisteredAtUtc });
        }
    }

}
