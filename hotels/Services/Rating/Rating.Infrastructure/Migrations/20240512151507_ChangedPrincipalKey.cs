using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rating.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedPrincipalKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelReview_Guest_GuestId",
                table: "HotelReview");

            migrationBuilder.AlterColumn<int>(
                name: "GuestId",
                table: "HotelReview",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Guest_GuestId",
                table: "Guest",
                column: "GuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelReview_Guest_GuestId",
                table: "HotelReview",
                column: "GuestId",
                principalTable: "Guest",
                principalColumn: "GuestId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelReview_Guest_GuestId",
                table: "HotelReview");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Guest_GuestId",
                table: "Guest");

            migrationBuilder.AlterColumn<int>(
                name: "GuestId",
                table: "HotelReview",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelReview_Guest_GuestId",
                table: "HotelReview",
                column: "GuestId",
                principalTable: "Guest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
