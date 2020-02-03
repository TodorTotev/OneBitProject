namespace PA.Tests.Infrastructure.Seeding
{
    using Persistence;

    public interface ITestSeeder
    {
        void Seed(ApplicationDbContext dbContext);
    }
}