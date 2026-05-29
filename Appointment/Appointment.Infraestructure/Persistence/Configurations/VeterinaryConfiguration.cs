using Appointment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Appointment.Infrastructure.Persistence.Configurations
{
    public class VeterinarianConfiguration : IEntityTypeConfiguration<Veterinarian>
    {
        public void Configure(EntityTypeBuilder<Veterinarian> builder)
        {
            builder.ToTable("apt_veterinarians");
            builder.HasKey(v => v.Id);
            builder.Property(v => v.FullName).IsRequired().HasMaxLength(200);
            builder.Property(v => v.LicenseNumber).IsRequired().HasMaxLength(50);
            builder.HasIndex(v => v.LicenseNumber).IsUnique();
            builder.Property(v => v.Specialty).IsRequired().HasMaxLength(100);
            builder.Property(v => v.CreatedAt).IsRequired();
            builder.Property(v => v.UpdatedAt).IsRequired();
        }
    }
}
