using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Xlkdma.Models
{
    public partial class XlkhdmaContext : DbContext
    {
        public XlkhdmaContext()
            : base("name=XlkhdmaContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerWorker> CustomerWorkers { get; set; }
        public virtual DbSet<Done> Dones { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Wait> Waits { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }
        public virtual DbSet<WorkerSkill> WorkerSkills { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.categoryName)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.customerName)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.customerCity)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.customerEmail)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.customerPassword)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.CustomerWorkers)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Waits)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerWorker>()
                .Property(e => e.skill)
                .IsFixedLength();

            modelBuilder.Entity<Job>()
                .Property(e => e.jobName)
                .IsFixedLength();

            modelBuilder.Entity<Job>()
                .Property(e => e.jobImage)
                .IsFixedLength();

            modelBuilder.Entity<Worker>()
                .Property(e => e.workerName)
                .IsFixedLength();

            modelBuilder.Entity<Worker>()
                .Property(e => e.workerCity)
                .IsFixedLength();

            modelBuilder.Entity<Worker>()
                .Property(e => e.workerPassword)
                .IsFixedLength();

            modelBuilder.Entity<Worker>()
                .Property(e => e.workerImage)
                .IsFixedLength();

            modelBuilder.Entity<Worker>()
                .HasMany(e => e.CustomerWorkers)
                .WithRequired(e => e.Worker)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Worker>()
                .HasMany(e => e.Waits)
                .WithRequired(e => e.Worker)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Worker>()
                .HasMany(e => e.WorkerSkills)
                .WithRequired(e => e.Worker)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkerSkill>()
                .Property(e => e.workerSkill1)
                .IsFixedLength();
        }
    }
}
