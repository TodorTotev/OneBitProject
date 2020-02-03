using PA.Tests.Infrastructure.Seeding;

namespace PA.Tests.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Persistence;
    using Tests.Infrastructure.Seeding;
    using WebApi.Tests.Infrastructure;

    public class ApplicationDbContextFactory
    {
        public static ApplicationDbContext Create()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(DateTime.Now.ToString(CultureInfo.InvariantCulture) + Guid.NewGuid().ToString())
                .ReplaceService<IModelCacheKeyFactory, CustomDynamicModelCacheKeyFactory>()
                .Options;

            var dbContext = new ApplicationDbContext(dbContextOptions);
            dbContext.Database.EnsureCreated();

            Seed(dbContext);

            dbContext.SaveChanges();

            return dbContext;
        }

        public static void Seed(ApplicationDbContext dbContext)
        {
            var seeders = new List<ITestSeeder>
            {
                new CustomerSeeder(),
                new OrderSeeder(),
            };

            foreach (var seeder in seeders)
            {
                seeder.Seed(dbContext);
                dbContext.SaveChangesAsync();
            }
        }

        public static void Destroy(ApplicationDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}