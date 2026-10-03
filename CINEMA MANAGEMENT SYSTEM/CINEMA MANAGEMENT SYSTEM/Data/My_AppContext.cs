using CINEMA_MANAGEMENT_SYSTEM.Models;
using Microsoft.EntityFrameworkCore;

namespace CINEMA_MANAGEMENT_SYSTEM.Data
{
    public class My_AppContext : DbContext
    {
        public My_AppContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Genre> Genres { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                .HasMany(g => g.Movies)
                .WithOne(m => m.Genre)
                .HasForeignKey(m => m.GenreId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Bookings)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Bookings)
                .WithOne(b => b.Movie)
                .HasForeignKey(b => b.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Genre>().HasIndex(g => g.Name).IsUnique();
            modelBuilder.Entity<Movie>().HasIndex(g => g.Title).IsUnique();
            modelBuilder.Entity<Customer>().HasIndex(g => g.Email).IsUnique();
            modelBuilder.Entity<Booking>().Property(x => x.BookingDate).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<Movie>().Property(x => x.TicketPrice).HasPrecision(10, 2);

            // =========================
            // Genres
            // =========================
            modelBuilder.Entity<Genre>().HasData(
        new Genre
        {
            Id = 1,
            Name = "Action"
        },
        new Genre
        {
            Id = 2,
            Name = "Comedy"
        },
        new Genre
        {
            Id = 3,
            Name = "Drama"
        },
        new Genre
        {
            Id = 4,
            Name = "Horror"
        },
        new Genre
        {
            Id = 5,
            Name = "Science Fiction"
        }
    );

            // =========================
            // Movies
            // =========================
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "Inception",
                    Director = "Christopher Nolan",
                    Duration = 148,
                    ReleaseYear = 2010,
                    Rating = 8.8,
                    TicketPrice = 150,
                    AvailableSeats = 100,
                    GenreId = 5
                },
                new Movie
                {
                    Id = 2,
                    Title = "The Dark Knight",
                    Director = "Christopher Nolan",
                    Duration = 152,
                    ReleaseYear = 2008,
                    Rating = 9.0,
                    TicketPrice = 180,
                    AvailableSeats = 120,
                    GenreId = 1
                },
                new Movie
                {
                    Id = 3,
                    Title = "The Hangover",
                    Director = "Todd Phillips",
                    Duration = 100,
                    ReleaseYear = 2009,
                    Rating = 7.7,
                    TicketPrice = 120,
                    AvailableSeats = 80,
                    GenreId = 2
                },
                new Movie
                {
                    Id = 4,
                    Title = "The Shawshank Redemption",
                    Director = "Frank Darabont",
                    Duration = 142,
                    ReleaseYear = 1994,
                    Rating = 9.3,
                    TicketPrice = 130,
                    AvailableSeats = 90,
                    GenreId = 3
                },
                new Movie
                {
                    Id = 5,
                    Title = "The Conjuring",
                    Director = "James Wan",
                    Duration = 112,
                    ReleaseYear = 2013,
                    Rating = 7.5,
                    TicketPrice = 140,
                    AvailableSeats = 70,
                    GenreId = 4
                }
            );

            // =========================
            // Customers
            // =========================
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    FullName = "Ahmed Hassan",
                    Email = "ahmed@gmail.com",
                    PhoneNumber = "01010000001"
                },
                new Customer
                {
                    Id = 2,
                    FullName = "Mona Adel",
                    Email = "mona@gmail.com",
                    PhoneNumber = "01010000002"
                },
                new Customer
                {
                    Id = 3,
                    FullName = "Omar Mohamed",
                    Email = "omar@gmail.com",
                    PhoneNumber = "01010000003"
                },
                new Customer
                {
                    Id = 4,
                    FullName = "Sara Ali",
                    Email = "sara@gmail.com",
                    PhoneNumber = "01010000004"
                }
            );

            // =========================
            // Bookings
            // =========================
            modelBuilder.Entity<Booking>().HasData(
                new Booking
                {
                    Id = 1,
                    BookingDate = new DateTime(2026, 10, 1),
                    NumberOfTickets = 2,
                    TotalPrice = 300,
                    CustomerId = 1,
                    MovieId = 1
                },
                new Booking
                {
                    Id = 2,
                    BookingDate = new DateTime(2026, 10, 1),
                    NumberOfTickets = 3,
                    TotalPrice = 540,
                    CustomerId = 2,
                    MovieId = 2
                },
                new Booking
                {
                    Id = 3,
                    BookingDate = new DateTime(2026, 10, 2),
                    NumberOfTickets = 1,
                    TotalPrice = 120,
                    CustomerId = 3,
                    MovieId = 3
                },
                new Booking
                {
                    Id = 4,
                    BookingDate = new DateTime(2026, 10, 2),
                    NumberOfTickets = 2,
                    TotalPrice = 260,
                    CustomerId = 4,
                    MovieId = 4
                },
                new Booking
                {
                    Id = 5,
                    BookingDate = new DateTime(2026, 10, 2),
                    NumberOfTickets = 4,
                    TotalPrice = 560,
                    CustomerId = 1,
                    MovieId = 5
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
