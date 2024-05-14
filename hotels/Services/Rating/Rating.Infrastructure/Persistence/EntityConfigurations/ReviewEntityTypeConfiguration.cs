using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

            builder.Property<int>("HotelId")
                .HasColumnType("INTEGER")
                .HasColumnName("HotelId")
                .IsRequired();

            builder.HasOne(hr => hr.HotelGuest)
                .WithMany(g => g.hotelReviews)
                .HasForeignKey(hr => hr.GuestId)
                .HasPrincipalKey(g => g.GuestId);

            builder.OwnsOne(o => o.HotelRating);     
            
        }
    }
}