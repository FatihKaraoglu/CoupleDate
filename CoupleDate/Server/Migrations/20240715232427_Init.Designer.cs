﻿// <auto-generated />
using System;
using CoupleDate.Server.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoupleDate.Server.Migrations
{
    [DbContext(typeof(DatingDbContext))]
    [Migration("20240715232427_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CoupleDate.Shared.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Romantic"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Casual"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Outdoors"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Entertainment"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Food & Drink"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Learning"
                        });
                });

            modelBuilder.Entity("CoupleDate.Shared.DateIdea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DateIdeas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Enjoy a fine dining experience.",
                            ImageUrl = "dinner.jpg",
                            Title = "Dinner at a fancy restaurant"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Explore nature on a hiking trail.",
                            ImageUrl = "hiking.jpg",
                            Title = "Hiking trip"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Watch the latest blockbuster.",
                            ImageUrl = "movie.jpg",
                            Title = "Movie night"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Relax with a picnic in the park.",
                            ImageUrl = "picnic.jpg",
                            Title = "Picnic in the park"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Spend a day at the beach.",
                            ImageUrl = "beach.jpg",
                            Title = "Beach day"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Learn to cook a new dish together.",
                            ImageUrl = "cooking.jpg",
                            Title = "Cooking class"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Sample different wines at a vineyard.",
                            ImageUrl = "wine.jpg",
                            Title = "Wine tasting"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Explore art and history at a museum.",
                            ImageUrl = "museum.jpg",
                            Title = "Museum visit"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Enjoy a fun night of bowling.",
                            ImageUrl = "bowling.jpg",
                            Title = "Bowling night"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Watch the stars together in a quiet spot.",
                            ImageUrl = "stargazing.jpg",
                            Title = "Stargazing"
                        },
                        new
                        {
                            Id = 11,
                            Description = "Have fun at an amusement park.",
                            ImageUrl = "amusementpark.jpg",
                            Title = "Amusement park"
                        },
                        new
                        {
                            Id = 12,
                            Description = "Attend a live music concert.",
                            ImageUrl = "concert.jpg",
                            Title = "Concert"
                        },
                        new
                        {
                            Id = 13,
                            Description = "Spend a night under the stars camping.",
                            ImageUrl = "camping.jpg",
                            Title = "Camping"
                        },
                        new
                        {
                            Id = 14,
                            Description = "Enjoy ice skating together.",
                            ImageUrl = "iceskating.jpg",
                            Title = "Ice skating"
                        },
                        new
                        {
                            Id = 15,
                            Description = "Sing your heart out at a karaoke bar.",
                            ImageUrl = "karaoke.jpg",
                            Title = "Karaoke night"
                        },
                        new
                        {
                            Id = 16,
                            Description = "Take a spontaneous road trip.",
                            ImageUrl = "roadtrip.jpg",
                            Title = "Road trip"
                        },
                        new
                        {
                            Id = 17,
                            Description = "Experience a hot air balloon ride.",
                            ImageUrl = "hotairballoon.jpg",
                            Title = "Hot air balloon ride"
                        },
                        new
                        {
                            Id = 18,
                            Description = "Solve puzzles in an escape room.",
                            ImageUrl = "escaperoom.jpg",
                            Title = "Escape room"
                        },
                        new
                        {
                            Id = 19,
                            Description = "Have fun playing mini golf.",
                            ImageUrl = "minigolf.jpg",
                            Title = "Mini golf"
                        },
                        new
                        {
                            Id = 20,
                            Description = "Make pottery together in a class.",
                            ImageUrl = "pottery.jpg",
                            Title = "Pottery class"
                        },
                        new
                        {
                            Id = 21,
                            Description = "Watch a live theater play.",
                            ImageUrl = "theater.jpg",
                            Title = "Theater play"
                        },
                        new
                        {
                            Id = 22,
                            Description = "See animals at the zoo.",
                            ImageUrl = "zoo.jpg",
                            Title = "Zoo visit"
                        },
                        new
                        {
                            Id = 23,
                            Description = "Go for a bike ride together.",
                            ImageUrl = "biking.jpg",
                            Title = "Biking"
                        },
                        new
                        {
                            Id = 24,
                            Description = "Explore a local farmers market.",
                            ImageUrl = "farmersmarket.jpg",
                            Title = "Farmers market"
                        },
                        new
                        {
                            Id = 25,
                            Description = "Go horseback riding.",
                            ImageUrl = "horsebackriding.jpg",
                            Title = "Horseback riding"
                        },
                        new
                        {
                            Id = 26,
                            Description = "Cook a meal together at home.",
                            ImageUrl = "cookingathome.jpg",
                            Title = "Cooking at home"
                        },
                        new
                        {
                            Id = 27,
                            Description = "Play board games.",
                            ImageUrl = "boardgames.jpg",
                            Title = "Board games"
                        },
                        new
                        {
                            Id = 28,
                            Description = "Volunteer at a local charity.",
                            ImageUrl = "volunteer.jpg",
                            Title = "Volunteer together"
                        },
                        new
                        {
                            Id = 29,
                            Description = "Go fishing together.",
                            ImageUrl = "fishing.jpg",
                            Title = "Fishing"
                        },
                        new
                        {
                            Id = 30,
                            Description = "Take a dance class.",
                            ImageUrl = "danceclass.jpg",
                            Title = "Dance class"
                        },
                        new
                        {
                            Id = 31,
                            Description = "Take photos together.",
                            ImageUrl = "photography.jpg",
                            Title = "Photography day"
                        },
                        new
                        {
                            Id = 32,
                            Description = "Relax with a spa day.",
                            ImageUrl = "spa.jpg",
                            Title = "Spa day"
                        },
                        new
                        {
                            Id = 33,
                            Description = "Have a cooking competition.",
                            ImageUrl = "cookingcompetition.jpg",
                            Title = "Cooking competition"
                        },
                        new
                        {
                            Id = 34,
                            Description = "Enjoy a trivia night.",
                            ImageUrl = "trivia.jpg",
                            Title = "Trivia night"
                        },
                        new
                        {
                            Id = 35,
                            Description = "Plant a garden together.",
                            ImageUrl = "garden.jpg",
                            Title = "Plant a garden"
                        },
                        new
                        {
                            Id = 36,
                            Description = "Visit an art gallery.",
                            ImageUrl = "artgallery.jpg",
                            Title = "Art gallery"
                        },
                        new
                        {
                            Id = 37,
                            Description = "Browse books at a bookstore.",
                            ImageUrl = "bookstore.jpg",
                            Title = "Bookstore date"
                        },
                        new
                        {
                            Id = 38,
                            Description = "Go surfing together.",
                            ImageUrl = "surfing.jpg",
                            Title = "Surfing"
                        },
                        new
                        {
                            Id = 39,
                            Description = "Experience jet skiing.",
                            ImageUrl = "jetskiing.jpg",
                            Title = "Jet skiing"
                        },
                        new
                        {
                            Id = 40,
                            Description = "Go rock climbing.",
                            ImageUrl = "rockclimbing.jpg",
                            Title = "Rock climbing"
                        },
                        new
                        {
                            Id = 41,
                            Description = "Join a cooking workshop.",
                            ImageUrl = "cookingworkshop.jpg",
                            Title = "Cooking workshop"
                        },
                        new
                        {
                            Id = 42,
                            Description = "Attend a yoga class together.",
                            ImageUrl = "yoga.jpg",
                            Title = "Yoga class"
                        },
                        new
                        {
                            Id = 43,
                            Description = "Visit a dog park with your pets.",
                            ImageUrl = "dogpark.jpg",
                            Title = "Dog park"
                        },
                        new
                        {
                            Id = 44,
                            Description = "Explore an aquarium.",
                            ImageUrl = "aquarium.jpg",
                            Title = "Aquarium visit"
                        },
                        new
                        {
                            Id = 45,
                            Description = "Have fun at a trampoline park.",
                            ImageUrl = "trampolinepark.jpg",
                            Title = "Trampoline park"
                        },
                        new
                        {
                            Id = 46,
                            Description = "Play laser tag.",
                            ImageUrl = "lasertag.jpg",
                            Title = "Laser tag"
                        },
                        new
                        {
                            Id = 47,
                            Description = "Race go-karts together.",
                            ImageUrl = "gokart.jpg",
                            Title = "Go-kart racing"
                        },
                        new
                        {
                            Id = 48,
                            Description = "Take a painting class.",
                            ImageUrl = "painting.jpg",
                            Title = "Painting class"
                        },
                        new
                        {
                            Id = 49,
                            Description = "Have fun with a scavenger hunt.",
                            ImageUrl = "scavengerhunt.jpg",
                            Title = "Scavenger hunt"
                        },
                        new
                        {
                            Id = 50,
                            Description = "Go skiing together.",
                            ImageUrl = "skiing.jpg",
                            Title = "Skiing"
                        });
                });

            modelBuilder.Entity("CoupleDate.Shared.DateIdeaCategory", b =>
                {
                    b.Property<int>("DateIdeaId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("DateIdeaId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("DateIdeaCategories");

                    b.HasData(
                        new
                        {
                            DateIdeaId = 1,
                            CategoryId = 1
                        },
                        new
                        {
                            DateIdeaId = 1,
                            CategoryId = 6
                        },
                        new
                        {
                            DateIdeaId = 2,
                            CategoryId = 2
                        },
                        new
                        {
                            DateIdeaId = 2,
                            CategoryId = 4
                        },
                        new
                        {
                            DateIdeaId = 3,
                            CategoryId = 5
                        },
                        new
                        {
                            DateIdeaId = 4,
                            CategoryId = 4
                        },
                        new
                        {
                            DateIdeaId = 4,
                            CategoryId = 3
                        },
                        new
                        {
                            DateIdeaId = 5,
                            CategoryId = 4
                        },
                        new
                        {
                            DateIdeaId = 5,
                            CategoryId = 3
                        },
                        new
                        {
                            DateIdeaId = 6,
                            CategoryId = 6
                        },
                        new
                        {
                            DateIdeaId = 6,
                            CategoryId = 7
                        },
                        new
                        {
                            DateIdeaId = 7,
                            CategoryId = 6
                        },
                        new
                        {
                            DateIdeaId = 8,
                            CategoryId = 5
                        },
                        new
                        {
                            DateIdeaId = 8,
                            CategoryId = 7
                        },
                        new
                        {
                            DateIdeaId = 9,
                            CategoryId = 5
                        },
                        new
                        {
                            DateIdeaId = 9,
                            CategoryId = 3
                        },
                        new
                        {
                            DateIdeaId = 10,
                            CategoryId = 1
                        },
                        new
                        {
                            DateIdeaId = 10,
                            CategoryId = 4
                        },
                        new
                        {
                            DateIdeaId = 11,
                            CategoryId = 2
                        },
                        new
                        {
                            DateIdeaId = 11,
                            CategoryId = 5
                        },
                        new
                        {
                            DateIdeaId = 12,
                            CategoryId = 5
                        },
                        new
                        {
                            DateIdeaId = 13,
                            CategoryId = 2
                        },
                        new
                        {
                            DateIdeaId = 13,
                            CategoryId = 4
                        },
                        new
                        {
                            DateIdeaId = 14,
                            CategoryId = 3
                        },
                        new
                        {
                            DateIdeaId = 14,
                            CategoryId = 4
                        },
                        new
                        {
                            DateIdeaId = 15,
                            CategoryId = 5
                        },
                        new
                        {
                            DateIdeaId = 15,
                            CategoryId = 3
                        },
                        new
                        {
                            DateIdeaId = 16,
                            CategoryId = 2
                        },
                        new
                        {
                            DateIdeaId = 16,
                            CategoryId = 3
                        },
                        new
                        {
                            DateIdeaId = 17,
                            CategoryId = 2
                        },
                        new
                        {
                            DateIdeaId = 17,
                            CategoryId = 1
                        },
                        new
                        {
                            DateIdeaId = 18,
                            CategoryId = 2
                        },
                        new
                        {
                            DateIdeaId = 18,
                            CategoryId = 3
                        },
                        new
                        {
                            DateIdeaId = 19,
                            CategoryId = 3
                        },
                        new
                        {
                            DateIdeaId = 19,
                            CategoryId = 5
                        },
                        new
                        {
                            DateIdeaId = 20,
                            CategoryId = 3
                        },
                        new
                        {
                            DateIdeaId = 20,
                            CategoryId = 7
                        },
                        new
                        {
                            DateIdeaId = 21,
                            CategoryId = 5
                        },
                        new
                        {
                            DateIdeaId = 22,
                            CategoryId = 4
                        },
                        new
                        {
                            DateIdeaId = 23,
                            CategoryId = 4
                        },
                        new
                        {
                            DateIdeaId = 23,
                            CategoryId = 3
                        },
                        new
                        {
                            DateIdeaId = 24,
                            CategoryId = 3
                        },
                        new
                        {
                            DateIdeaId = 24,
                            CategoryId = 6
                        },
                        new
                        {
                            DateIdeaId = 25,
                            CategoryId = 2
                        },
                        new
                        {
                            DateIdeaId = 25,
                            CategoryId = 4
                        },
                        new
                        {
                            DateIdeaId = 26,
                            CategoryId = 3
                        },
                        new
                        {
                            DateIdeaId = 26,
                            CategoryId = 6
                        },
                        new
                        {
                            DateIdeaId = 27,
                            CategoryId = 3
                        },
                        new
                        {
                            DateIdeaId = 27,
                            CategoryId = 5
                        },
                        new
                        {
                            DateIdeaId = 28,
                            CategoryId = 3
                        },
                        new
                        {
                            DateIdeaId = 28,
                            CategoryId = 4
                        },
                        new
                        {
                            DateIdeaId = 29,
                            CategoryId = 2
                        },
                        new
                        {
                            DateIdeaId = 29,
                            CategoryId = 4
                        },
                        new
                        {
                            DateIdeaId = 30,
                            CategoryId = 3
                        },
                        new
                        {
                            DateIdeaId = 30,
                            CategoryId = 7
                        },
                        new
                        {
                            DateIdeaId = 31,
                            CategoryId = 3
                        },
                        new
                        {
                            DateIdeaId = 31,
                            CategoryId = 7
                        },
                        new
                        {
                            DateIdeaId = 32,
                            CategoryId = 1
                        },
                        new
                        {
                            DateIdeaId = 32,
                            CategoryId = 3
                        },
                        new
                        {
                            DateIdeaId = 33,
                            CategoryId = 3
                        },
                        new
                        {
                            DateIdeaId = 33,
                            CategoryId = 6
                        },
                        new
                        {
                            DateIdeaId = 34,
                            CategoryId = 5
                        },
                        new
                        {
                            DateIdeaId = 34,
                            CategoryId = 3
                        },
                        new
                        {
                            DateIdeaId = 35,
                            CategoryId = 3
                        },
                        new
                        {
                            DateIdeaId = 35,
                            CategoryId = 4
                        },
                        new
                        {
                            DateIdeaId = 36,
                            CategoryId = 5
                        },
                        new
                        {
                            DateIdeaId = 37,
                            CategoryId = 3
                        },
                        new
                        {
                            DateIdeaId = 37,
                            CategoryId = 5
                        },
                        new
                        {
                            DateIdeaId = 38,
                            CategoryId = 2
                        },
                        new
                        {
                            DateIdeaId = 38,
                            CategoryId = 4
                        },
                        new
                        {
                            DateIdeaId = 39,
                            CategoryId = 2
                        },
                        new
                        {
                            DateIdeaId = 39,
                            CategoryId = 4
                        },
                        new
                        {
                            DateIdeaId = 40,
                            CategoryId = 2
                        },
                        new
                        {
                            DateIdeaId = 40,
                            CategoryId = 4
                        },
                        new
                        {
                            DateIdeaId = 41,
                            CategoryId = 6
                        },
                        new
                        {
                            DateIdeaId = 41,
                            CategoryId = 7
                        },
                        new
                        {
                            DateIdeaId = 42,
                            CategoryId = 3
                        },
                        new
                        {
                            DateIdeaId = 42,
                            CategoryId = 7
                        },
                        new
                        {
                            DateIdeaId = 43,
                            CategoryId = 3
                        },
                        new
                        {
                            DateIdeaId = 43,
                            CategoryId = 4
                        },
                        new
                        {
                            DateIdeaId = 44,
                            CategoryId = 5
                        },
                        new
                        {
                            DateIdeaId = 44,
                            CategoryId = 3
                        },
                        new
                        {
                            DateIdeaId = 45,
                            CategoryId = 3
                        },
                        new
                        {
                            DateIdeaId = 45,
                            CategoryId = 5
                        },
                        new
                        {
                            DateIdeaId = 46,
                            CategoryId = 5
                        },
                        new
                        {
                            DateIdeaId = 46,
                            CategoryId = 2
                        },
                        new
                        {
                            DateIdeaId = 47,
                            CategoryId = 5
                        },
                        new
                        {
                            DateIdeaId = 47,
                            CategoryId = 2
                        },
                        new
                        {
                            DateIdeaId = 48,
                            CategoryId = 3
                        },
                        new
                        {
                            DateIdeaId = 48,
                            CategoryId = 7
                        },
                        new
                        {
                            DateIdeaId = 49,
                            CategoryId = 3
                        },
                        new
                        {
                            DateIdeaId = 49,
                            CategoryId = 2
                        },
                        new
                        {
                            DateIdeaId = 50,
                            CategoryId = 2
                        },
                        new
                        {
                            DateIdeaId = 50,
                            CategoryId = 4
                        });
                });

            modelBuilder.Entity("CoupleDate.Shared.Invitation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Expiration")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Invitations");
                });

            modelBuilder.Entity("CoupleDate.Shared.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CoupleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSubscribed")
                        .HasColumnType("bit");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ProfilePictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CoupleDate.Shared.UserSwipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CoupleId")
                        .HasColumnType("int");

                    b.Property<int>("DateIdeaId")
                        .HasColumnType("int");

                    b.Property<bool>("Liked")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserSwipes");
                });

            modelBuilder.Entity("CoupleDate.Shared.DateIdeaCategory", b =>
                {
                    b.HasOne("CoupleDate.Shared.Category", "Category")
                        .WithMany("DateIdeaCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoupleDate.Shared.DateIdea", "DateIdea")
                        .WithMany("DateIdeaCategories")
                        .HasForeignKey("DateIdeaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("DateIdea");
                });

            modelBuilder.Entity("CoupleDate.Shared.UserSwipe", b =>
                {
                    b.HasOne("CoupleDate.Shared.User", "User")
                        .WithMany("UserSwipes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CoupleDate.Shared.Category", b =>
                {
                    b.Navigation("DateIdeaCategories");
                });

            modelBuilder.Entity("CoupleDate.Shared.DateIdea", b =>
                {
                    b.Navigation("DateIdeaCategories");
                });

            modelBuilder.Entity("CoupleDate.Shared.User", b =>
                {
                    b.Navigation("UserSwipes");
                });
#pragma warning restore 612, 618
        }
    }
}