using System;
using System.Collections.Generic;
using System.Text;
using Appointment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Appointment.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        public DbSet<Appointment.Domain.Entities.Appointments> Apt_Appointments { get; private set; }
        public DbSet<Veterinarian> Apt_Veterinarians { get; private set; }
        public DbSet<MedicalRecord> Apt_MedicalRecords { get; private set; }
    }
}
