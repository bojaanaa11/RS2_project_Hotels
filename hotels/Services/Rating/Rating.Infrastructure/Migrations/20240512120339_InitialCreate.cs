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
            migrationBuilder.Sql(@"
        IF NOT EXISTS (SELECT 1 FROM sys.sequences WHERE name = 'guestseq')
        BEGIN
            CREATE SEQUENCE [guestseq] START WITH 1 INCREMENT BY 10 NO MINVALUE NO MAXVALUE NO CYCLE;
        END
    ");

            migrationBuilder.Sql(@"
        IF NOT EXISTS (SELECT 1 FROM sys.sequences WHERE name = 'hotelratingcollectionseq')
        BEGIN
            CREATE SEQUENCE [hotelratingcollectionseq] START WITH 1 INCREMENT BY 10 NO MINVALUE NO MAXVALUE NO CYCLE;
        END
    ");
            migrationBuilder.Sql(@"
        IF NOT EXISTS (SELECT 1 FROM sys.sequences WHERE name = 'hotelreviewseq')
        BEGIN
            CREATE SEQUENCE [hotelreviewseq] START WITH 1 INCREMENT BY 10 NO MINVALUE NO MAXVALUE NO CYCLE;
        END
    ");
            
            migrationBuilder.DropTable(
                name: "HotelReview");

            migrationBuilder.DropTable(
                name: "Guest");

            migrationBuilder.DropTable(
                name: "HotelRatingCollection");

            migrationBuilder.CreateTable(
                name: "Guest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    GuestId = table.Column<int>(type: "INTEGER", nullable: false),
                    GuestName = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    EmailAddress = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    ReservationId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotelRatingCollection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<int>(type: "INTEGER", nullable: false),
                    HotelName = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRatingCollection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotelReview",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<int>(type: "INTEGER", nullable: false),
                    GuestId = table.Column<int>(type: "int", nullable: false),
                    HotelRating_Rating = table.Column<int>(type: "int", nullable: false),
                    HotelRating_Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelRating_RatingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HotelRatingCollectionId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelReview_Guest_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelReview_HotelRatingCollection_HotelRatingCollectionId",
                        column: x => x.HotelRatingCollectionId,
                        principalTable: "HotelRatingCollection",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelReview_GuestId",
                table: "HotelReview",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelReview_HotelRatingCollectionId",
                table: "HotelReview",
                column: "HotelRatingCollectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelReview");

            migrationBuilder.DropTable(
                name: "Guest");

            migrationBuilder.DropTable(
                name: "HotelRatingCollection");

            migrationBuilder.Sql("DROP SEQUENCE IF EXISTS [guestseq];");
        
            migrationBuilder.Sql("DROP SEQUENCE IF EXISTS [hotelratingcollectionseq];");
            
            migrationBuilder.Sql("DROP SEQUENCE IF EXISTS [hotelreviewseq];");
        }
    }
}
