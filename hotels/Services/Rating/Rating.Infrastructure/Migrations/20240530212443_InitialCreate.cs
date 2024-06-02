using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rating.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "hotelreviewseq",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "ratingprocessseq",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "RatingProcess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservationId = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    GuestId = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Status = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingProcess", x => x.Id);
                    table.UniqueConstraint("AK_RatingProcess_GuestId_ReservationId", x => new { x.GuestId, x.ReservationId });
                });

            migrationBuilder.CreateTable(
                name: "HotelReview",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    GuestId = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    ReservationId = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    HotelRating_Rating = table.Column<int>(type: "int", nullable: false),
                    HotelRating_Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelRating_RatingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelReview_RatingProcess_GuestId_ReservationId",
                        columns: x => new { x.GuestId, x.ReservationId },
                        principalTable: "RatingProcess",
                        principalColumns: new[] { "GuestId", "ReservationId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelReview_GuestId_ReservationId",
                table: "HotelReview",
                columns: new[] { "GuestId", "ReservationId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RatingProcess_ReservationId",
                table: "RatingProcess",
                column: "ReservationId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelReview");

            migrationBuilder.DropTable(
                name: "RatingProcess");

            migrationBuilder.DropSequence(
                name: "hotelreviewseq");

            migrationBuilder.DropSequence(
                name: "ratingprocessseq");
        }
    }
}
