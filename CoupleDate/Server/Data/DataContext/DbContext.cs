using CoupleDate.Shared;
using Microsoft.EntityFrameworkCore;

namespace CoupleDate.Server.Data.DataContext
{
    public class DatingDbContext : DbContext
    {
        public DatingDbContext(DbContextOptions<DatingDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; } 
        public DbSet<DateIdea> DateIdeas { get; set; }
        public DbSet<UserSwipe> UserSwipes { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DateIdeaCategory> DateIdeaCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DateIdea>().HasKey(d => d.Id);

            modelBuilder.Entity<UserSwipe>()
            .HasOne(us => us.User)
            .WithMany(u => u.UserSwipes)
            .HasForeignKey(us => us.UserId);

            modelBuilder.Entity<User>()
             .HasMany(u => u.UserSwipes)
             .WithOne(us => us.User)
             .HasForeignKey(us => us.UserId);

            modelBuilder.Entity<DateIdeaCategory>()
               .HasKey(dic => new { dic.DateIdeaId, dic.CategoryId });

            modelBuilder.Entity<DateIdeaCategory>()
                .HasOne(dic => dic.DateIdea)
                .WithMany(di => di.DateIdeaCategories)
                .HasForeignKey(dic => dic.DateIdeaId);

            modelBuilder.Entity<DateIdeaCategory>()
                .HasOne(dic => dic.Category)
                .WithMany(c => c.DateIdeaCategories)
                .HasForeignKey(dic => dic.CategoryId);


            modelBuilder.Entity<DateIdea>().HasData(
              new DateIdea { Id = 1, Title = "Dinner at a fancy restaurant", Description = "Enjoy a fine dining experience.", ImageUrl = "dinner.jpg" },
              new DateIdea { Id = 2, Title = "Hiking trip", Description = "Explore nature on a hiking trail.", ImageUrl = "hiking.jpg" },
              new DateIdea { Id = 3, Title = "Movie night", Description = "Watch the latest blockbuster.", ImageUrl = "movie.jpg" },
              new DateIdea { Id = 4, Title = "Picnic in the park", Description = "Relax with a picnic in the park.", ImageUrl = "picnic.jpg" },
              new DateIdea { Id = 5, Title = "Beach day", Description = "Spend a day at the beach.", ImageUrl = "beach.jpg" },
              new DateIdea { Id = 6, Title = "Cooking class", Description = "Learn to cook a new dish together.", ImageUrl = "cooking.jpg" },
              new DateIdea { Id = 7, Title = "Wine tasting", Description = "Sample different wines at a vineyard.", ImageUrl = "wine.jpg" },
              new DateIdea { Id = 8, Title = "Museum visit", Description = "Explore art and history at a museum.", ImageUrl = "museum.jpg" },
              new DateIdea { Id = 9, Title = "Bowling night", Description = "Enjoy a fun night of bowling.", ImageUrl = "bowling.jpg" },
              new DateIdea { Id = 10, Title = "Stargazing", Description = "Watch the stars together in a quiet spot.", ImageUrl = "stargazing.jpg" },
              new DateIdea { Id = 11, Title = "Amusement park", Description = "Have fun at an amusement park.", ImageUrl = "amusementpark.jpg" },
              new DateIdea { Id = 12, Title = "Concert", Description = "Attend a live music concert.", ImageUrl = "concert.jpg" },
              new DateIdea { Id = 13, Title = "Camping", Description = "Spend a night under the stars camping.", ImageUrl = "camping.jpg" },
              new DateIdea { Id = 14, Title = "Ice skating", Description = "Enjoy ice skating together.", ImageUrl = "iceskating.jpg" },
              new DateIdea { Id = 15, Title = "Karaoke night", Description = "Sing your heart out at a karaoke bar.", ImageUrl = "karaoke.jpg" },
              new DateIdea { Id = 16, Title = "Road trip", Description = "Take a spontaneous road trip.", ImageUrl = "roadtrip.jpg" },
              new DateIdea { Id = 17, Title = "Hot air balloon ride", Description = "Experience a hot air balloon ride.", ImageUrl = "hotairballoon.jpg" },
              new DateIdea { Id = 18, Title = "Escape room", Description = "Solve puzzles in an escape room.", ImageUrl = "escaperoom.jpg" },
              new DateIdea { Id = 19, Title = "Mini golf", Description = "Have fun playing mini golf.", ImageUrl = "minigolf.jpg" },
              new DateIdea { Id = 20, Title = "Pottery class", Description = "Make pottery together in a class.", ImageUrl = "pottery.jpg" },
              new DateIdea { Id = 21, Title = "Theater play", Description = "Watch a live theater play.", ImageUrl = "theater.jpg" },
              new DateIdea { Id = 22, Title = "Zoo visit", Description = "See animals at the zoo.", ImageUrl = "zoo.jpg" },
              new DateIdea { Id = 23, Title = "Biking", Description = "Go for a bike ride together.", ImageUrl = "biking.jpg" },
              new DateIdea { Id = 24, Title = "Farmers market", Description = "Explore a local farmers market.", ImageUrl = "farmersmarket.jpg" },
              new DateIdea { Id = 25, Title = "Horseback riding", Description = "Go horseback riding.", ImageUrl = "horsebackriding.jpg" },
              new DateIdea { Id = 26, Title = "Cooking at home", Description = "Cook a meal together at home.", ImageUrl = "cookingathome.jpg" },
              new DateIdea { Id = 27, Title = "Board games", Description = "Play board games.", ImageUrl = "boardgames.jpg" },
              new DateIdea { Id = 28, Title = "Volunteer together", Description = "Volunteer at a local charity.", ImageUrl = "volunteer.jpg" },
              new DateIdea { Id = 29, Title = "Fishing", Description = "Go fishing together.", ImageUrl = "fishing.jpg" },
              new DateIdea { Id = 30, Title = "Dance class", Description = "Take a dance class.", ImageUrl = "danceclass.jpg" },
              new DateIdea { Id = 31, Title = "Photography day", Description = "Take photos together.", ImageUrl = "photography.jpg" },
              new DateIdea { Id = 32, Title = "Spa day", Description = "Relax with a spa day.", ImageUrl = "spa.jpg" },
              new DateIdea { Id = 33, Title = "Cooking competition", Description = "Have a cooking competition.", ImageUrl = "cookingcompetition.jpg" },
              new DateIdea { Id = 34, Title = "Trivia night", Description = "Enjoy a trivia night.", ImageUrl = "trivia.jpg" },
              new DateIdea { Id = 35, Title = "Plant a garden", Description = "Plant a garden together.", ImageUrl = "garden.jpg" },
              new DateIdea { Id = 36, Title = "Art gallery", Description = "Visit an art gallery.", ImageUrl = "artgallery.jpg" },
              new DateIdea { Id = 37, Title = "Bookstore date", Description = "Browse books at a bookstore.", ImageUrl = "bookstore.jpg" },
              new DateIdea { Id = 38, Title = "Surfing", Description = "Go surfing together.", ImageUrl = "surfing.jpg" },
              new DateIdea { Id = 39, Title = "Jet skiing", Description = "Experience jet skiing.", ImageUrl = "jetskiing.jpg" },
              new DateIdea { Id = 40, Title = "Rock climbing", Description = "Go rock climbing.", ImageUrl = "rockclimbing.jpg" },
              new DateIdea { Id = 41, Title = "Cooking workshop", Description = "Join a cooking workshop.", ImageUrl = "cookingworkshop.jpg" },
              new DateIdea { Id = 42, Title = "Yoga class", Description = "Attend a yoga class together.", ImageUrl = "yoga.jpg" },
              new DateIdea { Id = 43, Title = "Dog park", Description = "Visit a dog park with your pets.", ImageUrl = "dogpark.jpg" },
              new DateIdea { Id = 44, Title = "Aquarium visit", Description = "Explore an aquarium.", ImageUrl = "aquarium.jpg" },
              new DateIdea { Id = 45, Title = "Trampoline park", Description = "Have fun at a trampoline park.", ImageUrl = "trampolinepark.jpg" },
              new DateIdea { Id = 46, Title = "Laser tag", Description = "Play laser tag.", ImageUrl = "lasertag.jpg" },
              new DateIdea { Id = 47, Title = "Go-kart racing", Description = "Race go-karts together.", ImageUrl = "gokart.jpg" },
              new DateIdea { Id = 48, Title = "Painting class", Description = "Take a painting class.", ImageUrl = "painting.jpg" },
              new DateIdea { Id = 49, Title = "Scavenger hunt", Description = "Have fun with a scavenger hunt.", ImageUrl = "scavengerhunt.jpg" },
              new DateIdea { Id = 50, Title = "Skiing", Description = "Go skiing together.", ImageUrl = "skiing.jpg" }
          );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Romantic" },
                new Category { Id = 2, Name = "Adventure" },
                new Category { Id = 3, Name = "Casual" },
                new Category { Id = 4, Name = "Outdoors" },
                new Category { Id = 5, Name = "Entertainment" },
                new Category { Id = 6, Name = "Food & Drink" },
                new Category { Id = 7, Name = "Learning" }
            );

            modelBuilder.Entity<DateIdeaCategory>().HasData(
                 new DateIdeaCategory { DateIdeaId = 1, CategoryId = 1 },
                 new DateIdeaCategory { DateIdeaId = 1, CategoryId = 6 },
                 new DateIdeaCategory { DateIdeaId = 2, CategoryId = 2 },
                 new DateIdeaCategory { DateIdeaId = 2, CategoryId = 4 },
                 new DateIdeaCategory { DateIdeaId = 3, CategoryId = 5 },
                 new DateIdeaCategory { DateIdeaId = 4, CategoryId = 4 },
                 new DateIdeaCategory { DateIdeaId = 4, CategoryId = 3 },
                 new DateIdeaCategory { DateIdeaId = 5, CategoryId = 4 },
                 new DateIdeaCategory { DateIdeaId = 5, CategoryId = 3 },
                 new DateIdeaCategory { DateIdeaId = 6, CategoryId = 6 },
                 new DateIdeaCategory { DateIdeaId = 6, CategoryId = 7 },
                 new DateIdeaCategory { DateIdeaId = 7, CategoryId = 6 },
                 new DateIdeaCategory { DateIdeaId = 8, CategoryId = 5 },
                 new DateIdeaCategory { DateIdeaId = 8, CategoryId = 7 },
                 new DateIdeaCategory { DateIdeaId = 9, CategoryId = 5 },
                 new DateIdeaCategory { DateIdeaId = 9, CategoryId = 3 },
                 new DateIdeaCategory { DateIdeaId = 10, CategoryId = 1 },
                 new DateIdeaCategory { DateIdeaId = 10, CategoryId = 4 },
                 new DateIdeaCategory { DateIdeaId = 11, CategoryId = 2 },
                 new DateIdeaCategory { DateIdeaId = 11, CategoryId = 5 },
                 new DateIdeaCategory { DateIdeaId = 12, CategoryId = 5 },
                 new DateIdeaCategory { DateIdeaId = 13, CategoryId = 2 },
                 new DateIdeaCategory { DateIdeaId = 13, CategoryId = 4 },
                 new DateIdeaCategory { DateIdeaId = 14, CategoryId = 3 },
                 new DateIdeaCategory { DateIdeaId = 14, CategoryId = 4 },
                 new DateIdeaCategory { DateIdeaId = 15, CategoryId = 5 },
                 new DateIdeaCategory { DateIdeaId = 15, CategoryId = 3 },
                 new DateIdeaCategory { DateIdeaId = 16, CategoryId = 2 },
                 new DateIdeaCategory { DateIdeaId = 16, CategoryId = 3 },
                 new DateIdeaCategory { DateIdeaId = 17, CategoryId = 2 },
                 new DateIdeaCategory { DateIdeaId = 17, CategoryId = 1 },
                 new DateIdeaCategory { DateIdeaId = 18, CategoryId = 2 },
                 new DateIdeaCategory { DateIdeaId = 18, CategoryId = 3 },
                 new DateIdeaCategory { DateIdeaId = 19, CategoryId = 3 },
                 new DateIdeaCategory { DateIdeaId = 19, CategoryId = 5 },
                 new DateIdeaCategory { DateIdeaId = 20, CategoryId = 3 },
                 new DateIdeaCategory { DateIdeaId = 20, CategoryId = 7 },
                 new DateIdeaCategory { DateIdeaId = 21, CategoryId = 5 },
                 new DateIdeaCategory { DateIdeaId = 22, CategoryId = 4 },
                 new DateIdeaCategory { DateIdeaId = 23, CategoryId = 4 },
                 new DateIdeaCategory { DateIdeaId = 23, CategoryId = 3 },
                 new DateIdeaCategory { DateIdeaId = 24, CategoryId = 3 },
                 new DateIdeaCategory { DateIdeaId = 24, CategoryId = 6 },
                 new DateIdeaCategory { DateIdeaId = 25, CategoryId = 2 },
                 new DateIdeaCategory { DateIdeaId = 25, CategoryId = 4 },
                 new DateIdeaCategory { DateIdeaId = 26, CategoryId = 3 },
                 new DateIdeaCategory { DateIdeaId = 26, CategoryId = 6 },
                 new DateIdeaCategory { DateIdeaId = 27, CategoryId = 3 },
                 new DateIdeaCategory { DateIdeaId = 27, CategoryId = 5 },
                 new DateIdeaCategory { DateIdeaId = 28, CategoryId = 3 },
                 new DateIdeaCategory { DateIdeaId = 28, CategoryId = 4 },
                 new DateIdeaCategory { DateIdeaId = 29, CategoryId = 2 },
                 new DateIdeaCategory { DateIdeaId = 29, CategoryId = 4 },
                 new DateIdeaCategory { DateIdeaId = 30, CategoryId = 3 },
                 new DateIdeaCategory { DateIdeaId = 30, CategoryId = 7 },
                 new DateIdeaCategory { DateIdeaId = 31, CategoryId = 3 },
                 new DateIdeaCategory { DateIdeaId = 31, CategoryId = 7 },
                 new DateIdeaCategory { DateIdeaId = 32, CategoryId = 1 },
                 new DateIdeaCategory { DateIdeaId = 32, CategoryId = 3 },
                 new DateIdeaCategory { DateIdeaId = 33, CategoryId = 3 },
                 new DateIdeaCategory { DateIdeaId = 33, CategoryId = 6 },
                 new DateIdeaCategory { DateIdeaId = 34, CategoryId = 5 },
                 new DateIdeaCategory { DateIdeaId = 34, CategoryId = 3 },
                 new DateIdeaCategory { DateIdeaId = 35, CategoryId = 3 },
                 new DateIdeaCategory { DateIdeaId = 35, CategoryId = 4 },
                 new DateIdeaCategory { DateIdeaId = 36, CategoryId = 5 },
                 new DateIdeaCategory { DateIdeaId = 37, CategoryId = 3 },
                 new DateIdeaCategory { DateIdeaId = 37, CategoryId = 5 },
                 new DateIdeaCategory { DateIdeaId = 38, CategoryId = 2 },
                 new DateIdeaCategory { DateIdeaId = 38, CategoryId = 4 },
                 new DateIdeaCategory { DateIdeaId = 39, CategoryId = 2 },
                 new DateIdeaCategory { DateIdeaId = 39, CategoryId = 4 },
                 new DateIdeaCategory { DateIdeaId = 40, CategoryId = 2 },
                 new DateIdeaCategory { DateIdeaId = 40, CategoryId = 4 },
                 new DateIdeaCategory { DateIdeaId = 41, CategoryId = 6 },
                 new DateIdeaCategory { DateIdeaId = 41, CategoryId = 7 },
                 new DateIdeaCategory { DateIdeaId = 42, CategoryId = 3 },
                 new DateIdeaCategory { DateIdeaId = 42, CategoryId = 7 },
                 new DateIdeaCategory { DateIdeaId = 43, CategoryId = 3 },
                 new DateIdeaCategory { DateIdeaId = 43, CategoryId = 4 },
                 new DateIdeaCategory { DateIdeaId = 44, CategoryId = 5 },
                 new DateIdeaCategory { DateIdeaId = 44, CategoryId = 3 },
                 new DateIdeaCategory { DateIdeaId = 45, CategoryId = 3 },
                 new DateIdeaCategory { DateIdeaId = 45, CategoryId = 5 },
                 new DateIdeaCategory { DateIdeaId = 46, CategoryId = 5 },
                 new DateIdeaCategory { DateIdeaId = 46, CategoryId = 2 },
                 new DateIdeaCategory { DateIdeaId = 47, CategoryId = 5 },
                 new DateIdeaCategory { DateIdeaId = 47, CategoryId = 2 },
                 new DateIdeaCategory { DateIdeaId = 48, CategoryId = 3 },
                 new DateIdeaCategory { DateIdeaId = 48, CategoryId = 7 },
                 new DateIdeaCategory { DateIdeaId = 49, CategoryId = 3 },
                 new DateIdeaCategory { DateIdeaId = 49, CategoryId = 2 },
                 new DateIdeaCategory { DateIdeaId = 50, CategoryId = 2 },
                 new DateIdeaCategory { DateIdeaId = 50, CategoryId = 4 }
             );
        }
    }

}
