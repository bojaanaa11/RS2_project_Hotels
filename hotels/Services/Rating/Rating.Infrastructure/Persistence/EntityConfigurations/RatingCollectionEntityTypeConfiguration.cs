using System;
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

            builder.Property<int>("HotelId")
                .HasColumnType("INTEGER")
                .HasColumnName("HotelId")
                .IsRequired();      

            builder.Property<string>("HotelName")
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("HotelName")
                .IsRequired();     

           var navigation = builder.Metadata.FindNavigation(nameof(HotelRatingCollection.Reviews))
                        ?? throw new UniqueRatingException($"No navigation property found on {nameof(HotelRatingCollection.Reviews)}");
                        navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}