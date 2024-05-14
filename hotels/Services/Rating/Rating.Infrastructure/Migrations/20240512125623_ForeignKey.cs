using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rating.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelReview_Guest_GuestId",
                table: "HotelReview");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelReview_HotelRatingCollection_HotelRatingCollectionId",
                table: "HotelReview");

            migrationBuilder.DropIndex(
                name: "IX_HotelReview_GuestId",
                table: "HotelReview");

            migrationBuilder.DropIndex(
                name: "IX_HotelReview_HotelRatingCollectionId",
                table: "HotelReview");

            migrationBuilder.DropColumn(
                name: "HotelRatingCollectionId",
                table: "HotelReview");

            migrationBuilder.AddColumn<int>(
                name: "RatingCollectionId",
                table: "HotelReview",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HotelReview_RatingCollectionId",
                table: "HotelReview",
                column: "RatingCollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelReview_Guest_Id",
                table: "HotelReview",
                column: "Id",
                principalTable: "Guest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelReview_HotelRatingCollection_RatingCollectionId",
                table: "HotelReview",
                column: "RatingCollectionId",
                principalTable: "HotelRatingCollection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelReview_Guest_Id",
                table: "HotelReview");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelReview_HotelRatingCollection_RatingCollectionId",
                table: "HotelReview");

            migrationBuilder.DropIndex(
                name: "IX_HotelReview_RatingCollectionId",
                table: "HotelReview");

            migrationBuilder.DropColumn(
                name: "RatingCollectionId",
                table: "HotelReview");

            migrationBuilder.AddColumn<int>(
                name: "HotelRatingCollectionId",
                table: "HotelReview",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelReview_GuestId",
                table: "HotelReview",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelReview_HotelRatingCollectionId",
                table: "HotelReview",
                column: "HotelRatingCollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelReview_Guest_GuestId",
                table: "HotelReview",
                column: "GuestId",
                principalTable: "Guest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelReview_HotelRatingCollection_HotelRatingCollectionId",
                table: "HotelReview",
                column: "HotelRatingCollectionId",
                principalTable: "HotelRatingCollection",
                principalColumn: "Id");
        }
    }
}
