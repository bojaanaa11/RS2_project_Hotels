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
    [Migration("20240611104004_AddHotelName")]
    partial class AddHotelName
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("hotelreviewseq")
                .IncrementsBy(10);

            modelBuilder.HasSequence("ratingprocessseq")
                .IncrementsBy(10);

            modelBuilder.Entity("Rating.Domain.Aggregates.RatingProcess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "ratingprocessseq");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GuestId")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("HotelId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("HotelName");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReservationId")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("ReservationId");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId")
                        .IsUnique();

                    b.ToTable("RatingProcess", (string)null);
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

                    b.Property<string>("GuestId")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("HotelId")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("HotelId");

                    b.Property<string>("HotelName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("HotelName");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReservationId")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("Id");

                    b.HasIndex("GuestId", "ReservationId")
                        .IsUnique();

                    b.ToTable("HotelReview", (string)null);
                });

            modelBuilder.Entity("Rating.Domain.Entities.HotelReview", b =>
                {
                    b.HasOne("Rating.Domain.Aggregates.RatingProcess", "RatingProcess")
                        .WithOne("Review")
                        .HasForeignKey("Rating.Domain.Entities.HotelReview", "GuestId", "ReservationId")
                        .HasPrincipalKey("Rating.Domain.Aggregates.RatingProcess", "GuestId", "ReservationId")
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

                    b.Navigation("HotelRating");

                    b.Navigation("RatingProcess");
                });

            modelBuilder.Entity("Rating.Domain.Aggregates.RatingProcess", b =>
                {
                    b.Navigation("Review");
                });
#pragma warning restore 612, 618
        }
    }
}
