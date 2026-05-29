using Microsoft.EntityFrameworkCore;
using Appointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        public DbSet<MedicalRecord> Appo_MedicalRecords { get; private set; }
    }
}
