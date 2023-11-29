using BooksApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksApp.Data
{
    public class BooksDBContext : DbContext //representation of the database
    {
        public BooksDBContext(DbContextOptions<BooksDBContext> options) 
        : base(options)
        {
        
        
        }

        public DbSet<Book> books { get; set; }//a DBSet is a c# representation of a table. Here we are adding the books table to the DBContext class

        protected override void OnModelCreating(ModelBuilder modelBuilder) //override the base class
        {
            modelBuilder.Entity<Book>().HasData(

                new Book { BookId = 1,
                    Author = "Dominic Feightner",
                    Description = "This has no description",
                    Title = "C# for Beginners",
                    Genre = "Coding",
                    Price = 24.99m,
                    DatePublished = new DateTime(2023, 10, 5) 
                },


                new Book
                {
                    BookId = 2,
                    Author = "Adam Freeman",
                    Description = "This has no description",
                    Title = "Advanced C# Development",
                    Genre = "Coding",
                    Price = 59.99m,
                    DatePublished = new DateTime(2021, 10, 5)
                },
                new Book
                {
                    BookId = 3,
                    Author = "Morgan Freeman",
                    Description = "This has no description",
                    Title = "HTML for Beginners",
                    Genre = "Coding",
                    Price = 19.99m,
                    DatePublished = new DateTime(2020, 5, 5)
                }


                );
        }
    }
}
