using DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureEfPersistance.Configurations
{
    public class TestResultConfiguration : IEntityTypeConfiguration<TestResult>
    {
        public void Configure(EntityTypeBuilder<TestResult> builder)
        {
            builder.ToTable("TestResults", "dbo");
            builder.HasKey(r => r.TestResultId);
            builder.Property(r => r.ResultValue).HasMaxLength(500).IsUnicode(true).IsRequired();
            builder.Property(r => r.Description).HasMaxLength(1000).IsUnicode(true).IsRequired(false);
            builder.Property(r => r.EnteredAtUtc).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSUTCDATETIME()");
            builder.Property(r => r.ModifiedAtUtc).HasColumnType("datetime2(0)").IsRequired(false);
            builder.Property(r => r.RowVersion).IsRowVersion();

            builder.HasIndex(r => r.TestRequestItemId).IsUnique();

            builder.HasOne(r => r.TestRequestItem)
                .WithOne(i => i.TestResult)
                .HasForeignKey<TestResult>(r => r.TestRequestItemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Status)
                .WithMany(s => s.TestResults)
                .HasForeignKey(r => r.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.EnteredByEmployee)
                .WithMany(e => e.TestResults)
                .HasForeignKey(r => r.EnteredByEmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
