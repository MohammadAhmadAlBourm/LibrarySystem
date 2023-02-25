using LibrarySystem.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Data
{
    public class LibraryDBContext : DbContext
    {
        public LibraryDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Author> authors { get; set; }
        public DbSet<Book> books { get; set; }

    }
}
