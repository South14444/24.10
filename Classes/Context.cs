using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Classes
{
    class Context : DbContext
    {
        private readonly IConfiguration configuration;
        DbSet<Model> game { get; set; }
        public Context()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public void GetAllGames()
        {
            foreach(var item in game)
            {
                Console.WriteLine(
                    $"{item.NameOfGame}" +
                    $"{item.Company} {item.Style} " +
                    $"{item.DateOfPublication}" +
                    $"{item.GameMode} {item.CountOfCopies}");
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=GameShop;Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model>().HasData(new Model()
            {
                Id = 1,
                NameOfGame = "NewGame",
                Company = "GamesINC",
                Style = "Shooter",
                DateOfPublication = DateTime.Now,
                GameMode = "Multiplayer",
                CountOfCopies = 100
            });
            modelBuilder.Entity<Model>().HasData(new Model()
            {
                Id = 1,
                NameOfGame = "UltraKill",
                Company = "TopGames",
                Style = "Shooter",
                DateOfPublication = DateTime.Now,
                GameMode = "SinglePlayer/MultiPlayer",
                CountOfCopies = 1000
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
