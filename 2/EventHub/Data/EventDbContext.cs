using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EventHub.Data
{
    public class EventDbContext : DbContext
    {
        public DbSet<model.Event> Events { get; set; }
        public DbSet<model.Attendee> Attendees { get; set; }
        public DbSet<model.Badge> Badges { get; set; }
        public DbSet<model.Oragnizer> Oragnizers { get; set; }
        public DbSet<model.EventRegisteration> EventRegisterations { get; set; }
        public DbSet<model.OrgnizerProfile> OrgnizerProfiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=EventHub;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<model.OrgnizerProfile>()
            .HasOne(op=>op.Organizer)
            .WithOne(o=>o.OrgnizerProfile)
            .HasForeignKey<model.OrgnizerProfile>(op=>op.OrganizerId)
            .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<model.Badge>(b =>
            {
                b.HasKey(b=>b.Id);
                b.Property(b=>b.UniqueCode).IsRequired().HasMaxLength(50);
                b.Property(b=>b.Tire).IsRequired();
                b.HasOne(b=>b.Attendee)
                .WithOne(a=>a.Badge)
                .HasForeignKey<model.Badge>(b=>b.AttendeeId)
                .OnDelete(DeleteBehavior.Cascade);
            });

           
        }
            


    }
}