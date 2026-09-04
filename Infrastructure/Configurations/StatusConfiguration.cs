using DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureEfPersistance.Configurations
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("Statuses", "dbo");
            builder.HasKey(s => s.StatusId);
            builder.Property(s => s.Code).HasMaxLength(50).IsUnicode(false).IsRequired();
            builder.Property(s => s.Title).HasMaxLength(100).IsUnicode(true).IsRequired();
            builder.Property(s => s.EntityName).HasMaxLength(30).IsUnicode(false).IsRequired();
            builder.Property(s => s.DisplayOrder).HasDefaultValue((short)0);
            builder.Property(s => s.IsFinal).HasDefaultValue(false);
            builder.Property(s => s.IsActive).HasDefaultValue(true);

            builder.HasIndex(s => new { s.EntityName, s.Code }).IsUnique();
            builder.HasIndex(s => new { s.EntityName, s.DisplayOrder }).IsUnique();
        }
    }
}
