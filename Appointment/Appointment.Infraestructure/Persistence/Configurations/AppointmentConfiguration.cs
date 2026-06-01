using Appointment.Domain.Entities;
using Appointment.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Appointment.Infrastructure.Persistence.Configurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment.Domain.Entities.Appointments>
    {
        public void Configure(EntityTypeBuilder<Appointment.Domain.Entities.Appointments> builder)
        {
            builder.ToTable("apt_appointments");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.PetId).IsRequired();
            builder.Property(a => a.OwnerId).IsRequired();
            builder.Property(a => a.VeterinarianId).IsRequired();
            builder.Property(a => a.ScheduleStart).IsRequired();
            builder.Property(a => a.ScheduleEnd).IsRequired();
            builder.Property(a => a.Status).IsRequired().HasConversion<string>().HasMaxLength(20);
            builder.Property(a => a.Reason).IsRequired().HasMaxLength(500);
            builder.Property(a => a.Notes).HasMaxLength(1000);
            builder.Property(a => a.CancelReason).HasMaxLength(500);
            builder.Property(a => a.CreatedAt).IsRequired();
            builder.Property(a => a.UpdatedAt).IsRequired();

            builder.HasOne(a => a.Veterinarian)
                .WithMany(v => v.Appointments)
                .HasForeignKey(a => a.VeterinarianId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.MedicalRecord)
                .WithOne()
                .HasForeignKey<MedicalRecord>(m => m.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);
        }
    }
}
