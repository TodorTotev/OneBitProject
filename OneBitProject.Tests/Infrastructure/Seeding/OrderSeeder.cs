namespace OneBitProject.Tests.Infrastructure.Seeding
{
    using OneBigProject.Persistence;
    using OneBitProject.Domain.Entities;

    public class OrderSeeder : ITestSeeder
    {
        public void Seed(ApplicationDbContext dbContext)
        {
            dbContext.Orders.AddAsync(new Order
            {
                Id = 1,
                Description = "Test",
                Quantity = 100000,
                TotalAmount = 10000,
                Status = "Active",
                CustomerId = 1,
            });

            dbContext.Orders.AddAsync(new Order
            {
                Id = 2,
                Description = "Test2",
                Quantity = 1,
                TotalAmount = 1,
                Status = "Inactive",
                IsDeleted = true,
                CustomerId = 2,
            });
        }
    }
}