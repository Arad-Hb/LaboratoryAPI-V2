using DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureEfPersistance.Configurations
{
    public class SampleTypeConfiguration : IEntityTypeConfiguration<SampleType>
    {
        public void Configure(EntityTypeBuilder<SampleType> builder)
        {
            builder.ToTable("SampleTypes", "dbo");
            builder.HasKey(s => s.SampleTypeId);
            builder.Property(s => s.Code).HasMaxLength(30).IsUnicode(false).IsRequired();
            builder.Property(s => s.Name).HasMaxLength(100).IsUnicode(true).IsRequired();
            builder.Property(s => s.IsActive).HasDefaultValue(true);

            builder.HasIndex(s => s.Code).IsUnique();
        }
    }
}
