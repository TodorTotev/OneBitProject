namespace OneBitProject.Tests.Infrastructure.Seeding
{
    using OneBigProject.Persistence;

    public interface ITestSeeder
    {
        void Seed(ApplicationDbContext dbContext);
    }
}