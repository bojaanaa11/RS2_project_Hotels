using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rating.Domain.Entities;

namespace Rating.Infrastructure.Persistence.EntityConfigurations
{
    public class GuestEntityTypeConfiguration : IEntityTypeConfiguration<Guest>
    {
        public void Configure(EntityTypeBuilder<Guest> builder)
        {
            builder.ToTable("Guest");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).UseHiLo("guestseq");

            builder.Property<int>("GuestId")
                .HasColumnType("INTEGER")
                .HasColumnName("GuestId")
                .IsRequired();

            builder.Property<string>("GuestName")
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("GuestName")
                .IsRequired();
            
            builder.Property<string>("EmailAddress")
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("EmailAddress")
                .IsRequired();

            builder.Property<int>("ReservationId")
                .HasColumnType("INTEGER")
                .HasColumnName("ReservationId")
                .IsRequired();
        }
    }
}