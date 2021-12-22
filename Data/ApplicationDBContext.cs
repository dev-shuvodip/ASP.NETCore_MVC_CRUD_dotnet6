using Microsoft.EntityFrameworkCore;
using WebApp_demo.Models;

namespace WebApp_demo.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
