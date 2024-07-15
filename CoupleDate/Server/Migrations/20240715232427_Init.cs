using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoupleDate.Server.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DateIdeas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateIdeas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invitations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invitations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSubscribed = table.Column<bool>(type: "bit", nullable: false),
                    CoupleId = table.Column<int>(type: "int", nullable: true),
                    ProfilePictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DateIdeaCategories",
                columns: table => new
                {
                    DateIdeaId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateIdeaCategories", x => new { x.DateIdeaId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_DateIdeaCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DateIdeaCategories_DateIdeas_DateIdeaId",
                        column: x => x.DateIdeaId,
                        principalTable: "DateIdeas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSwipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateIdeaId = table.Column<int>(type: "int", nullable: false),
                    Liked = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CoupleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSwipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSwipes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Romantic" },
                    { 2, "Adventure" },
                    { 3, "Casual" },
                    { 4, "Outdoors" },
                    { 5, "Entertainment" },
                    { 6, "Food & Drink" },
                    { 7, "Learning" }
                });

            migrationBuilder.InsertData(
                table: "DateIdeas",
                columns: new[] { "Id", "Description", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { 1, "Enjoy a fine dining experience.", "dinner.jpg", "Dinner at a fancy restaurant" },
                    { 2, "Explore nature on a hiking trail.", "hiking.jpg", "Hiking trip" },
                    { 3, "Watch the latest blockbuster.", "movie.jpg", "Movie night" },
                    { 4, "Relax with a picnic in the park.", "picnic.jpg", "Picnic in the park" },
                    { 5, "Spend a day at the beach.", "beach.jpg", "Beach day" },
                    { 6, "Learn to cook a new dish together.", "cooking.jpg", "Cooking class" },
                    { 7, "Sample different wines at a vineyard.", "wine.jpg", "Wine tasting" },
                    { 8, "Explore art and history at a museum.", "museum.jpg", "Museum visit" },
                    { 9, "Enjoy a fun night of bowling.", "bowling.jpg", "Bowling night" },
                    { 10, "Watch the stars together in a quiet spot.", "stargazing.jpg", "Stargazing" },
                    { 11, "Have fun at an amusement park.", "amusementpark.jpg", "Amusement park" },
                    { 12, "Attend a live music concert.", "concert.jpg", "Concert" },
                    { 13, "Spend a night under the stars camping.", "camping.jpg", "Camping" },
                    { 14, "Enjoy ice skating together.", "iceskating.jpg", "Ice skating" },
                    { 15, "Sing your heart out at a karaoke bar.", "karaoke.jpg", "Karaoke night" },
                    { 16, "Take a spontaneous road trip.", "roadtrip.jpg", "Road trip" },
                    { 17, "Experience a hot air balloon ride.", "hotairballoon.jpg", "Hot air balloon ride" },
                    { 18, "Solve puzzles in an escape room.", "escaperoom.jpg", "Escape room" },
                    { 19, "Have fun playing mini golf.", "minigolf.jpg", "Mini golf" },
                    { 20, "Make pottery together in a class.", "pottery.jpg", "Pottery class" },
                    { 21, "Watch a live theater play.", "theater.jpg", "Theater play" },
                    { 22, "See animals at the zoo.", "zoo.jpg", "Zoo visit" },
                    { 23, "Go for a bike ride together.", "biking.jpg", "Biking" },
                    { 24, "Explore a local farmers market.", "farmersmarket.jpg", "Farmers market" },
                    { 25, "Go horseback riding.", "horsebackriding.jpg", "Horseback riding" },
                    { 26, "Cook a meal together at home.", "cookingathome.jpg", "Cooking at home" },
                    { 27, "Play board games.", "boardgames.jpg", "Board games" },
                    { 28, "Volunteer at a local charity.", "volunteer.jpg", "Volunteer together" },
                    { 29, "Go fishing together.", "fishing.jpg", "Fishing" },
                    { 30, "Take a dance class.", "danceclass.jpg", "Dance class" },
                    { 31, "Take photos together.", "photography.jpg", "Photography day" },
                    { 32, "Relax with a spa day.", "spa.jpg", "Spa day" },
                    { 33, "Have a cooking competition.", "cookingcompetition.jpg", "Cooking competition" },
                    { 34, "Enjoy a trivia night.", "trivia.jpg", "Trivia night" },
                    { 35, "Plant a garden together.", "garden.jpg", "Plant a garden" },
                    { 36, "Visit an art gallery.", "artgallery.jpg", "Art gallery" },
                    { 37, "Browse books at a bookstore.", "bookstore.jpg", "Bookstore date" },
                    { 38, "Go surfing together.", "surfing.jpg", "Surfing" },
                    { 39, "Experience jet skiing.", "jetskiing.jpg", "Jet skiing" },
                    { 40, "Go rock climbing.", "rockclimbing.jpg", "Rock climbing" },
                    { 41, "Join a cooking workshop.", "cookingworkshop.jpg", "Cooking workshop" },
                    { 42, "Attend a yoga class together.", "yoga.jpg", "Yoga class" },
                    { 43, "Visit a dog park with your pets.", "dogpark.jpg", "Dog park" },
                    { 44, "Explore an aquarium.", "aquarium.jpg", "Aquarium visit" },
                    { 45, "Have fun at a trampoline park.", "trampolinepark.jpg", "Trampoline park" },
                    { 46, "Play laser tag.", "lasertag.jpg", "Laser tag" },
                    { 47, "Race go-karts together.", "gokart.jpg", "Go-kart racing" },
                    { 48, "Take a painting class.", "painting.jpg", "Painting class" },
                    { 49, "Have fun with a scavenger hunt.", "scavengerhunt.jpg", "Scavenger hunt" },
                    { 50, "Go skiing together.", "skiing.jpg", "Skiing" }
                });

            migrationBuilder.InsertData(
                table: "DateIdeaCategories",
                columns: new[] { "CategoryId", "DateIdeaId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 6, 1 },
                    { 2, 2 },
                    { 4, 2 },
                    { 5, 3 },
                    { 3, 4 },
                    { 4, 4 },
                    { 3, 5 },
                    { 4, 5 },
                    { 6, 6 },
                    { 7, 6 },
                    { 6, 7 },
                    { 5, 8 },
                    { 7, 8 },
                    { 3, 9 },
                    { 5, 9 },
                    { 1, 10 },
                    { 4, 10 },
                    { 2, 11 },
                    { 5, 11 },
                    { 5, 12 },
                    { 2, 13 },
                    { 4, 13 },
                    { 3, 14 },
                    { 4, 14 },
                    { 3, 15 },
                    { 5, 15 },
                    { 2, 16 },
                    { 3, 16 },
                    { 1, 17 },
                    { 2, 17 },
                    { 2, 18 },
                    { 3, 18 },
                    { 3, 19 },
                    { 5, 19 },
                    { 3, 20 },
                    { 7, 20 },
                    { 5, 21 },
                    { 4, 22 },
                    { 3, 23 },
                    { 4, 23 },
                    { 3, 24 },
                    { 6, 24 },
                    { 2, 25 },
                    { 4, 25 },
                    { 3, 26 },
                    { 6, 26 },
                    { 3, 27 },
                    { 5, 27 },
                    { 3, 28 },
                    { 4, 28 },
                    { 2, 29 },
                    { 4, 29 },
                    { 3, 30 },
                    { 7, 30 },
                    { 3, 31 },
                    { 7, 31 },
                    { 1, 32 },
                    { 3, 32 },
                    { 3, 33 },
                    { 6, 33 },
                    { 3, 34 },
                    { 5, 34 },
                    { 3, 35 },
                    { 4, 35 },
                    { 5, 36 },
                    { 3, 37 },
                    { 5, 37 },
                    { 2, 38 },
                    { 4, 38 },
                    { 2, 39 },
                    { 4, 39 },
                    { 2, 40 },
                    { 4, 40 },
                    { 6, 41 },
                    { 7, 41 },
                    { 3, 42 },
                    { 7, 42 },
                    { 3, 43 },
                    { 4, 43 },
                    { 3, 44 },
                    { 5, 44 },
                    { 3, 45 },
                    { 5, 45 },
                    { 2, 46 },
                    { 5, 46 },
                    { 2, 47 },
                    { 5, 47 },
                    { 3, 48 },
                    { 7, 48 },
                    { 2, 49 },
                    { 3, 49 },
                    { 2, 50 },
                    { 4, 50 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DateIdeaCategories_CategoryId",
                table: "DateIdeaCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSwipes_UserId",
                table: "UserSwipes",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DateIdeaCategories");

            migrationBuilder.DropTable(
                name: "Invitations");

            migrationBuilder.DropTable(
                name: "UserSwipes");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "DateIdeas");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
