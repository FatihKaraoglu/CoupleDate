using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoupleDate.Server.Migrations
{
    /// <inheritdoc />
    public partial class ImageUrlToDateIdea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "DateIdeas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "DateIdeas",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "card.jpg");

            migrationBuilder.UpdateData(
                table: "DateIdeas",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "card.jpg");

            migrationBuilder.UpdateData(
                table: "DateIdeas",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "card.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "DateIdeas");
        }
    }
}
