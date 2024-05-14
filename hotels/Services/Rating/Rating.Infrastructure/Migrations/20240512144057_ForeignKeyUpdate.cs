using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rating.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelReview_Guest_Id",
                table: "HotelReview");

            migrationBuilder.CreateIndex(
                name: "IX_HotelReview_GuestId",
                table: "HotelReview",
                column: "GuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelReview_Guest_GuestId",
                table: "HotelReview",
                column: "GuestId",
                principalTable: "Guest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelReview_Guest_GuestId",
                table: "HotelReview");

            migrationBuilder.DropIndex(
                name: "IX_HotelReview_GuestId",
                table: "HotelReview");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelReview_Guest_Id",
                table: "HotelReview",
                column: "Id",
                principalTable: "Guest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
