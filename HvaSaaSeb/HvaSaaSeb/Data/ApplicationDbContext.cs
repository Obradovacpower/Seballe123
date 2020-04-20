using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HvaSaaSeb.Models;

namespace HvaSaaSeb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        
        
        }
        public DbSet<GuestEntity> Guests { get; set; }
        public DbSet<RoomEntity> Rooms { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuestEntity>()
                .HasOne(a => a.Room)
                .WithMany(b => b.Guests);
            modelBuilder.Entity<GuestEntity>()
                .HasMany(a => a.Orders)
                .WithOne(b => b.Guest);
        }
    }
}
