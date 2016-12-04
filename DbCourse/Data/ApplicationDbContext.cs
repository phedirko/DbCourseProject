using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DbCourse.Models;

namespace DbCourse.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Client>().ToTable("Client");
            builder.Entity<Manager>().ToTable("Manager");
            builder.Entity<Office>().ToTable("Office");
            builder.Entity<Contract>().ToTable("Contract");
        }


        public DbSet<Client> Clients { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Application> Application { get; set; }
    }
}
