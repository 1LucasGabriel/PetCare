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

        public DbSet<Appointments> Appo_Appointments { get; private set; }
        public DbSet<Veterinarian> Appo_Veterinarians { get; private set; }
        public DbSet<MedicalRecord> Appo_MedicalRecords { get; private set; }
    }
}
