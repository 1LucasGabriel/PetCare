using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Appointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.Infrastructure.Persistence.Configurations
{
    public class MedicalRecordConfiguration : IEntityTypeConfiguration<MedicalRecord>
    {
        public void Configure(EntityTypeBuilder<MedicalRecord> builder)
        {
            builder.ToTable("appo_medicalrecords");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Diagnosis).IsRequired().HasMaxLength(100);
            builder.Property(m => m.Treatment).HasMaxLength(100);
            builder.Property(m => m.Prescriptions).HasConversion<string>().HasMaxLength(500);
            builder.Property(m => m.FollowUpDate).IsRequired(false);
            builder.Property(m => m.RecordedAt).IsRequired();
        }
    }
}
