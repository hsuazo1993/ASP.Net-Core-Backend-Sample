using DataAccess.Mappings;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class FruitContext : DbContext
    {
        public FruitContext(DbContextOptions<FruitContext> options)
            : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FruitMap());
            modelBuilder.ApplyConfiguration(new FruitTypeMap());

        }
        public DbSet<Fruit> Fruits { get; set; }
        public DbSet<FruitType> FruitTypes { get; set; }
    }
}
