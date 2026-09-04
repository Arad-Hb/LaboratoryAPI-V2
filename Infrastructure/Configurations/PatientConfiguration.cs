using DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureEfPersistance.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients", "dbo");
            builder.HasKey(p => p.PatientId);
            builder.Property(p => p.NationalCode).HasMaxLength(20).IsUnicode(false).IsRequired(false);
            builder.Property(p => p.FirstName).HasMaxLength(80).IsUnicode(true).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(100).IsUnicode(true).IsRequired();
            builder.Property(p => p.Mobile).HasMaxLength(20).IsUnicode(false).IsRequired(false);
            builder.Property(p => p.BirthDate).HasColumnType("date").IsRequired(false);
            builder.Property(p => p.CreatedAtUtc).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSUTCDATETIME()");
            
            builder.HasOne(r => r.RegisteredByEmployee)
              .WithMany(e => e.Patients)
              .HasForeignKey(r => r.RegisteredByEmployeeId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(p => p.NationalCode).IsUnique().HasFilter("[NationalCode] IS NOT NULL");
            builder.HasIndex(p => p.Mobile).HasFilter("[Mobile] IS NOT NULL");
        }
    }
}
