



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
        
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieCollection>().HasData(
                new MovieCollection
                {
                    MovieId = 1,
                    Category = "Action",
                    Title = "Top Gun: Maverick",
                    Year = 2022,
                    Director = "Joseph Kosinski",
                    Rating = "PG-13",
                    Edited = false

                },
                new MovieCollection
                {
                    MovieId = 2,
                    Category = "Action",
                    Title = "The Avengers",
                    Year = 2012,
                    Director = "Joss Whedon",
                    Rating = "PG-13",
                    Edited = false

                },
                new MovieCollection
                {
                    MovieId = 3,
                    Category = "Action",
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
