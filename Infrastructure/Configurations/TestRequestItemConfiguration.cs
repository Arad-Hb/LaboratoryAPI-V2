using DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureEfPersistance.Configurations
{
    public class TestRequestItemConfiguration : IEntityTypeConfiguration<TestRequestItem>
    {
        public void Configure(EntityTypeBuilder<TestRequestItem> builder)
        {
            builder.ToTable("TestRequestItems", "dbo");
            builder.HasKey(i => i.TestRequestItemId);
            builder.Property(i => i.TestNameSnapshot).HasMaxLength(150).IsUnicode(true).IsRequired();
            builder.Property(i => i.UnitSnapshot).HasMaxLength(50).IsUnicode(true).IsRequired(false);

            builder.HasIndex(i => new { i.TestRequestId, i.LaboratoryTestId }).IsUnique();

            builder.HasOne(i => i.TestRequest)
                .WithMany(r => r.Items)
                .HasForeignKey(i => i.TestRequestId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.LaboratoryTest)
                .WithMany(t => t.TestRequestItems)
                .HasForeignKey(i => i.LaboratoryTestId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.Sample)
                .WithMany(s => s.TestRequestItems)
                .HasForeignKey(i => i.SampleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
