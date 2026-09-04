using DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureEfPersistance.Configurations
{
    public class ResultReviewConfiguration : IEntityTypeConfiguration<ResultReview>
    {
        public void Configure(EntityTypeBuilder<ResultReview> builder)
        {
            builder.ToTable("ResultReviews", "dbo");
            builder.HasKey(v => v.ResultReviewId);
            builder.Property(v => v.ReviewDescription).HasMaxLength(1000).IsUnicode(true).IsRequired(false);
            builder.Property(v => v.ReviewedAtUtc).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSUTCDATETIME()");

            builder.HasOne(v => v.TestResult)
                .WithMany(r => r.ResultReviews)
                .HasForeignKey(v => v.TestResultId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(v => v.Status)
                .WithMany(s => s.ResultReviews)
                .HasForeignKey(v => v.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(v => v.ReviewedByEmployee)
                .WithMany(e => e.ResultReviews)
                .HasForeignKey(v => v.ReviewedByEmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(v => new { v.TestResultId, v.ReviewedAtUtc });
        }
    }
}
