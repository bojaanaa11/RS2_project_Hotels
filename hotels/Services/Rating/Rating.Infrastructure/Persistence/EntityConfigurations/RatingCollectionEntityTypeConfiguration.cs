/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rating.Domain.Aggregates;
using Rating.Domain.Exceptions;

namespace Rating.Infrastructure.Persistence.EntityConfigurations
{
    public class RatingCollectionEntityTypeConfiguration : IEntityTypeConfiguration<HotelRatingCollection>
    {
        public void Configure(EntityTypeBuilder<HotelRatingCollection> builder)
        {
            builder.ToTable("HotelRatingCollection");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).UseHiLo("hotelratingcollectionseq");

            builder.Property<string>("HotelId")
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("HotelId")
                .IsRequired();
            
            builder.Property<string>("HotelName")
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("HotelName")
                .IsRequired(false);
            
            builder.HasIndex(h => h.HotelId).IsUnique();
        }
    }
}*/