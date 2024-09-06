using MaxiShop.web.Models;
using Microsoft.EntityFrameworkCore;

namespace MaxiShop.web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }

        public DbSet<Category> Category { get; set; }

    }

}
