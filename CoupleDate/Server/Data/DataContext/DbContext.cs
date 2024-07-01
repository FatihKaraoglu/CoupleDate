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

            // Seed data
            modelBuilder.Entity<DateIdea>().HasData(
                new DateIdea { Id = 1, Title = "Dinner at a fancy restaurant", Description = "Enjoy a fine dining experience." },
                new DateIdea { Id = 2, Title = "Hiking trip", Description = "Explore nature on a hiking trail." },
                new DateIdea { Id = 3, Title = "Movie night", Description = "Watch the latest blockbuster." }
            );
        }
    }

}
