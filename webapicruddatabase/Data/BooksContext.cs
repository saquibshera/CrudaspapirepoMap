using Microsoft.EntityFrameworkCore;
using webapicruddatabase.Dtos;
using webapicruddatabase.Models;

namespace webapicruddatabase.Data
{
    public class BooksContext:DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options):base(options)
        {
            
        }
        public DbSet<BookDTO> TableBooks { get; set; }
    }
}
