
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskMan.Framework.Entities;
using TaskMan.Membership.Entities;

namespace TaskMan.Framework
{
    public class FrameworkContext : DbContext
    {
        // Made these readonly
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public FrameworkContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Task>()
                .HasOne(x => x.User)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Task>()
                .HasOne(x => x.AssignedTo)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(builder);
        }

        // ADD Your DBSet Here
    }

}
