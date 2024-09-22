using API_Bibliotek.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Bibliotek.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(

            new Book()
            {
                Id = 1,
                Title = "Skate",
                Author = "Tony Hawk",
                Year = 1995,
                Genre = "Lifestyle",
                Description = "Wanna kick it, but cant kick IT, learn to pop shove, kick flip and more rad stuff!",
                IsAvailable = true,
            },
            new Book()
            {
                Id = 2,
                Title = "Thunders Tropic",
                Author = "Danny McBride",
                Year = 2009,
                Genre = "Facts",
                Description = "What really happaend durring the filming?? I'll tell you, fuck all",
                IsAvailable = false,
            },
            new Book()
            {
                Id = 3,
                Title = "The Golden God",
                Author = "Dennis Raynolds",
                Year = 2016,
                Genre = "biography",
                Description = "How did he go from Nightman to The Golden God? Read and find out!!",
                IsAvailable = true,
            },
            new Book()
            {
                Id = 4,
                Title = "The Elder Scrolls",
                Author = "MacGuffin",
                Year = 1123,
                Genre = "Religon",
                Description = "DO NOT READ",
                IsAvailable = true,
            },
              new Book()
              {
                  Id = 5,
                  Title = "Codex Astartes",
                  Author = "Roboute Guilliman",
                  Year = 40403,
                  Genre = "Religon",
                  Description = "They shall be pure of heart and strong of body, " +
                                "untainted by doubt and unsullied by self-aggrandisement.",
                  IsAvailable = true,
              }
            );
        }

    }
}
