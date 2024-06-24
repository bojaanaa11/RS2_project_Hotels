using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rating.Domain.Aggregates;
using Rating.Domain.Entities;

namespace Rating.Infrastructure.Persistence.EntityConfigurations
{
    public class ReviewEntityTypeConfiguration : IEntityTypeConfiguration<HotelReview>
    {
        public void Configure(EntityTypeBuilder<HotelReview> builder)
        {
            builder.ToTable("HotelReview");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).UseHiLo("hotelreviewseq");

            builder.Property<string>("HotelId")
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("HotelId")
                .IsRequired();

            builder.Property<string>("HotelName")
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("HotelName")
                .IsRequired();

            builder.HasOne(hr => hr.RatingProcess)
                .WithOne(rp => rp.Review)
                .HasForeignKey<HotelReview>(hr => new { hr.GuestId, hr.ReservationId })
                .HasPrincipalKey<RatingProcess>(rp => new { rp.GuestId, rp.ReservationId });

            builder.OwnsOne(o => o.HotelRating);     
            
        }
    }
}