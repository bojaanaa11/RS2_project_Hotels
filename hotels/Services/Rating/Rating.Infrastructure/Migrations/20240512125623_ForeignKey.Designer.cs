﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rating.Infrastructure.Persistence;

#nullable disable

namespace Rating.Infrastructure.Migrations
{
    [DbContext(typeof(RatingContext))]
    [Migration("20240512125623_ForeignKey")]
    partial class ForeignKey
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("guestseq")
                .IncrementsBy(10);

            modelBuilder.HasSequence("hotelratingcollectionseq")
                .IncrementsBy(10);

            modelBuilder.HasSequence("hotelreviewseq")
                .IncrementsBy(10);

            modelBuilder.Entity("Rating.Domain.Aggregates.HotelRatingCollection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "hotelratingcollectionseq");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("HotelId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("HotelId");

                    b.Property<string>("HotelName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("HotelName");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("HotelRatingCollection", (string)null);
                });

            modelBuilder.Entity("Rating.Domain.Entities.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "guestseq");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("EmailAddress");

                    b.Property<int>("GuestId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("GuestId");

                    b.Property<string>("GuestName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("GuestName");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReservationId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ReservationId");

                    b.HasKey("Id");

                    b.ToTable("Guest", (string)null);
                });

            modelBuilder.Entity("Rating.Domain.Entities.HotelReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "hotelreviewseq");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GuestId")
                        .HasColumnType("int");

                    b.Property<int>("HotelId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("HotelId");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RatingCollectionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RatingCollectionId");

                    b.ToTable("HotelReview", (string)null);
                });

            modelBuilder.Entity("Rating.Domain.Entities.HotelReview", b =>
                {
                    b.HasOne("Rating.Domain.Entities.Guest", "HotelGuest")
                        .WithMany("hotelReviews")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rating.Domain.Aggregates.HotelRatingCollection", "RatingCollection")
                        .WithMany("Reviews")
                        .HasForeignKey("RatingCollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Rating.Domain.ValueObjects.RatingInformation", "HotelRating", b1 =>
                        {
                            b1.Property<int>("HotelReviewId")
                                .HasColumnType("int");

                            b1.Property<string>("Comment")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("Rating")
                                .HasColumnType("int");

                            b1.Property<DateTime?>("RatingDate")
                                .HasColumnType("datetime2");

                            b1.HasKey("HotelReviewId");

                            b1.ToTable("HotelReview");

                            b1.WithOwner()
                                .HasForeignKey("HotelReviewId");
                        });

                    b.Navigation("HotelGuest");

                    b.Navigation("HotelRating")
                        .IsRequired();

                    b.Navigation("RatingCollection");
                });

            modelBuilder.Entity("Rating.Domain.Aggregates.HotelRatingCollection", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Rating.Domain.Entities.Guest", b =>
                {
                    b.Navigation("hotelReviews");
                });
#pragma warning restore 612, 618
        }
    }
}
