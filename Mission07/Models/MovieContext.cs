using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission07.Models
{
    public class MovieContext : DbContext
    {
       // Constructor
        public MovieContext (DbContextOptions <MovieContext> options) : base(options)
        {
            // Leave blank for now
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set;}

        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, category = "Action" },
                new Category { CategoryId = 2, category = "Thriller" },
                new Category { CategoryId = 3, category = "Romantic" }
                ); 

            mb.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId = 1,
                    CategoryId = 1,
                    title = "Gladiator",
                    year = 2000,
                    director = "Ridley Scott",
                    rating = "R",
                    edited = false,

                },
                new Movie
                {
                    MovieId = 2,
                    CategoryId = 2,
                    title = "American Sniper",
                    year = 2014,
                    director = "Clint Eastwood",
                    rating = "R",
                    edited = false,
                },
                new Movie
                {
                    MovieId = 3,
                    CategoryId = 3,
                    title = "The Batman",
                    year = 2022,
                    director = "Matt Reeves",
                    rating = "PG-13",
                    edited = false,

                }
            );
        }
    }
}
