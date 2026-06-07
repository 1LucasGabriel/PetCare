using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Registration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Infrastructure.Persistence.Configurations
{
    public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable("reg_owners");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.FullName).IsRequired().HasMaxLength(200);

            builder.OwnsOne(o => o.CPF, cpf =>
            {
                cpf.Property(c => c.Value).HasColumnName("cpf").IsRequired().HasMaxLength(11);
                cpf.HasIndex(c => c.Value).IsUnique();
            });

            builder.OwnsOne(o => o.Email, email =>
            {
                email.Property(e => e.Value).HasColumnName("email").IsRequired().HasMaxLength(256);
            });

            builder.OwnsOne(o => o.Password, password =>
            {
                password.Property(p => p.Value).HasColumnName("Password").IsRequired().HasMaxLength(255);
            });
            builder.Property(o => o.Phone).HasMaxLength(20);
            builder.Property(o => o.CreatedAt).IsRequired();
            builder.Property(o => o.UpdatedAt).IsRequired();
            builder.HasMany(o => o.Pets).WithOne().HasForeignKey(p => p.OwnerId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
