using Microsoft.EntityFrameworkCore;
using WebApplication1.Controllers;

namespace WebApplication1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> Sections { get; set; }
    }
}