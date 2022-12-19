using Microsoft.EntityFrameworkCore;
using SampleTask.Application.Interfaces.Contexts;
using SampleTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTask.Persistence.Context
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Customer>().Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Customer>().Property(e => e.DateOfBirth)
                .HasColumnType("date");
            modelBuilder.Entity<Customer>().Property(e => e.PhoneNumber)
               .HasColumnType("nvarchar(13)")
               .IsRequired();
            modelBuilder.Entity<Customer>().Property(e => e.Email)
                .HasColumnType("nvarchar(50)")
                .IsRequired();
            

            modelBuilder.Entity<Customer>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Customer>().HasIndex(x => new { x.Name, x.DateOfBirth }).IsUnique();

            modelBuilder.Entity<Customer>().HasQueryFilter(p => !p.IsRemoved);


        }

    }
}
