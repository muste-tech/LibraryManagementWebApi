using Microsoft.EntityFrameworkCore;
using LibraryProject.Model;

namespace LibraryProject.Data
{
    public class LibraryDbContext : DbConText
    {
        public LibraryDbContext(DbContextOptions <LibraryDbContext> options)
        :base (options)
        {
            
        }
         public DbSet<Book> Books { get; set; }

         public DbSet<Author> Authors { get; set; }

         public DbSet<Category> Categories { get; set; }

         public DbSet<Member> Members { get; set; }

         public DbSet<BorrowRecord> BorrowRecords { get; set; }
    }
}