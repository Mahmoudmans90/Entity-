using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EventHub.configration
{
    public class EventConfiguration : IEntityTypeConfiguration<model.Event>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<model.Event> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Title).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Description).IsRequired().HasMaxLength(500);
            builder.Property(e=>e.StartDate).IsRequired();
            builder.Property(e=>e.MaxAttendees).IsRequired();
            builder.HasOne(e=>e.Organizer).WithMany(o=>o.Events).HasForeignKey(e=>e.OrganizerId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(e=>e.SubEvents).WithOne(e=>e.Parent).HasForeignKey(e=>e.ParentId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(e=>e.EventRegisterations).WithOne(er=>er.Event).HasForeignKey(er=>er.EventId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(e=>e.StartDate).HasDefaultValueSql("GETDATE()");
            
        }
    }
}