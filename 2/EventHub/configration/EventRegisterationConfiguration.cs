using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EventHub.configration
{
    public class EventRegisterationConfiguration : IEntityTypeConfiguration<model.EventRegisteration>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<model.EventRegisteration> builder)
        {
            builder.HasKey(er => er.Id);
            builder.Property(er=>er.Note).HasMaxLength(500);
            builder.Property(er=>er.RegisterationDate).HasDefaultValueSql("GETDATE()");
            
            builder.HasOne(er => er.Event).WithMany(e => e.EventRegisterations).HasForeignKey(er => er.EventId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(er => er.Attendee).WithMany(a => a.EventRegisterations).HasForeignKey(er => er.AttendeeId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}