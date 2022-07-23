using Microsoft.EntityFrameworkCore;
using TrainingSample.Models;

#nullable disable
namespace TrainingSample
{
    public class TrainingDbContext : DbContext
    {
        public TrainingDbContext(DbContextOptions<TrainingDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

    }
}
