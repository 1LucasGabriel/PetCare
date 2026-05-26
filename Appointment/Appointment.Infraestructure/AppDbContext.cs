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

        public DbSet<MedicalRecord> Reg_MedicalRecords { get; private set; }
        public DbSet<Appointments> Reg_Appointments { get; private set; }
    }
}
