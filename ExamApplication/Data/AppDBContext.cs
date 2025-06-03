using ExamApplication.Entity;
using Microsoft.EntityFrameworkCore;

namespace ExamApplication.Data
{

    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        // Define DbSets for your entities here
        public DbSet<FruitInventory> FruitInventories { get; set; }
    }

}
 





