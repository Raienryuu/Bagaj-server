using System.Collections.Generic;
using bAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace bAPI
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<UserDataModel> Users { get; set; }
        public DbSet<SessionModel> UserSessions { get; set; }
        public DbSet<RatingModel> Ratings { get; set; }
        public DbSet<PackageModel> Packages { get; set; }
        public DbSet<BidModel> Bids { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.UseSerialColumns();
            /*
            modelBuilder.Entity<UserDataModel>()
                .HasIndex(b => b.Login)
                .HasDatabaseName("Unique_login")
                .IsUnique();

            modelBuilder.Entity<SessionModel>()
                .HasIndex(b => b.Token)
                .HasDatabaseName("Unique_token")
                .IsUnique();
            */
            var users = new List<UserDataModel>();
            var sessions = new List<SessionModel>();
            
            var user = new UserDataModel
            {
                Id = 1,
                Login = "user1",
                Password = "haslo1",
                Name = "Tom",
                Lastname = "Berry",
                ContactInfo = "berries11@gmail.com"
            };
            users.Add(user);
            user = new UserDataModel
            {
                Id = 2,
                Login = "user2",
                Password = "haslo2",
                Name = "Paul",
                Lastname = "Jerry",
                ContactInfo = "mousepaul@yahoo.com"
            };
            users.Add(user);

            modelBuilder.Entity<SessionModel>().HasData(sessions);
            modelBuilder.Entity<UserDataModel>().HasData(users);
            
        }
    }
}
