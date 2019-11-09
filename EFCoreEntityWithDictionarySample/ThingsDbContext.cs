using Microsoft.EntityFrameworkCore;

namespace EFCoreEntityWithDictionarySample
{
    public class ThingsDbContext : DbContext
    {
        public DbSet<Something> Somethings { get; set; }

        public DbSet<AnotherThing> AnotherThings { get; set; }

        public ThingsDbContext(DbContextOptions<ThingsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SomethingConfiguration());
            modelBuilder.ApplyConfiguration(new AnotherThingConfiguration());
        }
    }
}
