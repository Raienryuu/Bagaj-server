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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var users = new List<UserDataModel>();
            var sessions = new List<SessionModel>();

            var newSession = new SessionModel();
            newSession.UserId = 42312313;
            newSession.Token = "Example token";
            newSession.Id = 1;

            sessions.Add(newSession);

            var user = new UserDataModel
            {
                Id = 1,
                Login = "user1",
                Password = "haslo1",
                Name = "Tom",
                Lastname = "Berry"
            };
            users.Add(user);
            user = new UserDataModel
            {
                Id = 2,
                Login = "user2",
                Password = "haslo2",
                Name = "Paul",
                Lastname = "Jerry"
            };
            users.Add(user);

            modelBuilder.Entity<SessionModel>().HasData(sessions);
            modelBuilder.Entity<UserDataModel>().HasData(users);
            
        }
    }
}
