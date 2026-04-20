using Microsoft.EntityFrameworkCore;
using _1.Models;

namespace ReadMoreBooks.Data
{
    public class BookStoreContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.\\SQLEXPRESS;Database=ReadMoreBooksDb;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}