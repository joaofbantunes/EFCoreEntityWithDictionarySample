using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace EFCoreEntityWithDictionarySample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection()
                .AddDbContext<ThingsDbContext>(options =>
                {
                    options.UseSqlite("Data Source = EFCoreEntityWithDictionarySample.db;");
                })
                .BuildServiceProvider();

            using (var scope = services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ThingsDbContext>();
                await db.Database.EnsureDeletedAsync();
                await db.Database.EnsureCreatedAsync();
            }

            using (var scope = services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ThingsDbContext>();
                var something = new Something();
                something.AddAnotherThing(new AnotherThing());

                db.Somethings.Add(something);
                await db.SaveChangesAsync();
            }

            using (var scope = services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ThingsDbContext>();
                var thing = await db.Somethings.Include("EfTargetThings").FirstAsync();
                Console.WriteLine($"Thing: {thing.Id} has {thing.Things.Count} other thing(s):");
                foreach (var anotherThing in thing.Things)
                {
                    Console.WriteLine($"> Another thing {anotherThing.Id}");
                }
            }
        }
    }
}
