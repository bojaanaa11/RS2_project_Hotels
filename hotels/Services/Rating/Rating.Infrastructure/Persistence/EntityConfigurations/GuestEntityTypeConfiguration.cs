/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rating.Domain.Aggregates;
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

            builder.Property<string>("GuestId")
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("GuestId")
                .IsRequired();
            
            builder.HasIndex(g => g.GuestId).IsUnique();
            
            builder.Property<string>("GuestName")
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("GuestName")
                .IsRequired(false);

            builder.Property<string>("EmailAddress")
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("EmailAddress")
                .IsRequired(false);
        }
    }
}*/