using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace Skill4.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            builder.UseSqlServer("server=DESKTOP-HH8LS46;database=Skill4DB;Trusted_Connection=true");
        }

        public DbSet<Employee> Employees { get; set; }
         public DbSet<CitiesClass> CitiesClasss { get; set; }
        public DbSet<Adminlog> Adminlogs { get; set; }
        public DbSet<Cities> Citiess { get; set; }
        public DbSet<ServiceProviderMaps> ServiceProviderMapss { get; set; }
        public DbSet<ServiceProviders> ServiceProviderss { get; set; }
        public DbSet<ServiceRequests> ServiceRequestss { get; set; }
        public DbSet<Services> Servicess { get; set; }
        public DbSet<Users> Userss { get; set; }
        public DbSet<RequestForProvider> RequestForProviders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
        }
    }
}