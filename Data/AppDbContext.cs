using Library_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<UserModel> Users => Set<UserModel>();
        public DbSet<BookModel> Books => Set<BookModel>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookModel>().HasData(
                new BookModel { Id = 1, Title = "Don Quixote", Author = "Miguel de Cervantes", ISBN = "9780060934347", CopiesAvailable = 4, TimesBorrowed = 6 },
                new BookModel { Id = 2, Title = "Alice's Adventures in Wonderland", Author = "Lewis Carroll", ISBN = "9781503250212", CopiesAvailable = 3, TimesBorrowed = 5 },
                new BookModel { Id = 3, Title = "The Lord of The Rings", Author = "J.R.R. Tolkien", ISBN = "9780261102385", CopiesAvailable = 5, TimesBorrowed = 12 },
                new BookModel { Id = 4, Title = "The Hobbit", Author = "J.R.R. Tolkien", ISBN = "9780261102217", CopiesAvailable = 2, TimesBorrowed = 9 },
                new BookModel { Id = 5, Title = "The Count of Monte Cristo", Author = "Alexandre Dumas", ISBN = "9780140449266", CopiesAvailable = 6, TimesBorrowed = 8 });
        }
    }
}
