using Appointment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Appointment.Infrastructure.Persistence.Configurations
{
    public class VeterinarianConfiguration : IEntityTypeConfiguration<Veterinarian>
    {
        public void Configure(EntityTypeBuilder<Veterinarian> builder)
        {
            builder.ToTable("appt_veterinarians");
            builder.HasKey(v => v.Id);
            builder.Property(v => v.FullName).IsRequired().HasMaxLength(200);
            builder.Property(v => v.Crmv).IsRequired().HasMaxLength(50);

            builder.OwnsOne(v => v.Email, email =>
            {
                email.Property(e => e.Value).HasColumnName("email").IsRequired().HasMaxLength(256);
            });

            builder.OwnsOne(v => v.Password, password =>
            {
                password.Property(p => p.Value).HasColumnName("Password").IsRequired().HasMaxLength(255);
            });
            builder.Property(v => v.Specialties).HasConversion<string>().HasMaxLength(500);
            builder.Property(v => v.CreatedAt).IsRequired();
            builder.Property(v => v.UpdatedAt).IsRequired();
        }
    }
}
