using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Registration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Infrastructure.Persistence.Configurations
{
    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable("reg_pets");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Species).IsRequired().HasConversion<string>().HasMaxLength(20);
            builder.Property(p => p.Breed).HasMaxLength(100);
            builder.Property(p => p.WeightKg).HasColumnType("decimal(5,2)");
            builder.Property(p => p.BirthDate).IsRequired(false);
            builder.Property(p => p.IsActive).IsRequired().HasDefaultValue(true);
            builder.Property(p => p.CreatedAt).IsRequired();
            builder.Property(p => p.UpdatedAt).IsRequired();
        }
    }
}
