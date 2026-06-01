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

        public DbSet<AppointmentEntity> Appt_Appointment { get; private set; }
        public DbSet<Veterinarian> Appt_Veterinarians { get; private set; }
        public DbSet<MedicalRecord> Appt_MedicalRecords { get; private set; }
    }
}
