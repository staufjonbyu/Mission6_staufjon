



using Microsoft.EntityFrameworkCore;

namespace Mission6_staufjon.Models
{
    public class MovieContext : DbContext
    {
        //constructor
        public MovieContext (DbContextOptions<MovieContext> options) : base(options) 
        { 
            // leave blank rn
        }

        public DbSet<MovieCollection> responses { get; set; } 
        public DbSet<Category> Categories { get; set; }


        // seed datat
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action" },
                new Category { CategoryId = 2, CategoryName = "Horror" },
                new Category { CategoryId = 3, CategoryName = "Comedy" },
                new Category { CategoryId = 4, CategoryName = "Drama" },
                new Category { CategoryId = 5, CategoryName = "Fantasy" }
                );
            mb.Entity<MovieCollection>().HasData(
                new MovieCollection
                {
                    MovieId = 1,
                    CategoryId = 1,
                    Title = "Top Gun: Maverick",
                    Year = 2022,
                    Director = "Joseph Kosinski",
                    Rating = "PG-13",
                    Edited = false

                },
                new MovieCollection
                {
                    MovieId = 2,
                    CategoryId = 1,
                    Title = "The Avengers",
                    Year = 2012,
                    Director = "Joss Whedon",
                    Rating = "PG-13",
                    Edited = false

                },
                new MovieCollection
                {
                    MovieId = 3,
                    CategoryId = 1,
                    Title = "Inception",
                    Year = 2010,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false

                }

                );
        }
    }
}
