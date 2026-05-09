using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EventHub.configration
{
    public class AttendeeConfiguration  : IEntityTypeConfiguration<model.Attendee>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<model.Attendee> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Email).IsRequired().HasMaxLength(100);
            builder.HasIndex(a=>a.Email).IsUnique();       
            builder.OwnsOne( a => a.Address, a =>
            {
                a.Property(ad => ad.Street).HasMaxLength(200).IsRequired().HasColumnName("Street");
                a.Property(ad => ad.City).HasMaxLength(100).IsRequired().HasColumnName("City");
                a.Property(ad => ad.Country).HasMaxLength(100).IsRequired().HasColumnName("Country");
                a.Property(ad => ad.PostalCode).HasMaxLength(20).IsRequired().HasColumnName("PostalCode");
            });
            builder.HasOne(a=>a.Badge).WithOne(b=>b.Attendee).HasForeignKey<model.Badge>(b=>b.AttendeeId);
            builder.HasMany(a=>a.EventRegisterations).WithOne(er=>er.Attendee).HasForeignKey(er=>er.AttendeeId);
        }
    }
}