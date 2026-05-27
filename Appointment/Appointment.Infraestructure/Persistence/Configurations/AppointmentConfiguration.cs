using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Appointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace Appointment.Infrastructure.Persistence.Configurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointments>
    {
        public void Configure(EntityTypeBuilder<Appointments> builder)
        {
            builder.ToTable("appo_appointments");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.PetId).IsRequired();
            builder.Property(a => a.OwnerId).IsRequired();
            builder.Property(a => a.VeterinarianId).IsRequired();
            builder.Property(a => a.ScheduleStart).IsRequired();
            builder.Property(a => a.ScheduleEnd).IsRequired();
            builder.Property(a => a.Status).IsRequired().HasConversion<string>().HasMaxLength(50);
            builder.Property(a => a.Reason).IsRequired().HasMaxLength(200);
            builder.Property(a => a.Notes).IsRequired(false).HasMaxLength(500);
            builder.Property(a => a.CancellationReason).IsRequired(false).HasMaxLength(200);
            builder.Property(a => a.CreatedAt).IsRequired();
            builder.Property(a => a.UpdatedAt).IsRequired();
        }
    }
}