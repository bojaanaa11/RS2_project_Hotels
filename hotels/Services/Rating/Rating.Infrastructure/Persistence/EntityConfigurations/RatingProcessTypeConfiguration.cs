using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rating.Domain.Aggregates;

namespace Rating.Infrastructure.Persistence.EntityConfigurations;

public class RatingProcessTypeConfiguration : IEntityTypeConfiguration<RatingProcess>
{
    public void Configure(EntityTypeBuilder<RatingProcess> builder)
    {
        builder.ToTable("RatingProcess");
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id).UseHiLo("ratingprocessseq");

        builder.Property<string>("ReservationId")
            .HasColumnType("VARCHAR(100)")
            .HasColumnName("ReservationId")
            .IsRequired();

        builder.HasIndex("ReservationId").IsUnique();
        
        builder.Property<string>("Status")
            .HasColumnType("VARCHAR(100)")
            .HasColumnName("Status")
            .IsRequired();
        
        builder.Property<string>("GuestId")
            .HasColumnType("VARCHAR(100)")
            .IsRequired();

        builder.Property<string>("HotelName")
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("HotelName")
                .IsRequired();

        builder.Property<string>("HotelId")
            .IsRequired();

    }
}