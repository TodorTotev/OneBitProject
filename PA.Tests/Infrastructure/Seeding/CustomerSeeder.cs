namespace PA.Tests.Infrastructure.Seeding
{
    using Persistence;
    using Domain.Entities;

    public class CustomerSeeder : ITestSeeder
    {
        public void Seed(ApplicationDbContext dbContext)
        {
            dbContext.Customers.AddAsync(new Customer
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Gender = "Male",
                PhoneNumber = "0885359164",
                Status = "Active",
            });

            dbContext.Customers.AddAsync(new Customer
            {
                Id = 2,
                FirstName = "John",
                LastName = "Doe",
                Gender = "Male",
                PhoneNumber = "0885359164",
                Status = "Active",
                IsDeleted = true,
            });
        }
    }
}