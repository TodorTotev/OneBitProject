using PA.Tests.Infrastructure;

namespace PA.Tests.Customer.Commands.Create
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Application.Customer.Commands.Create;
    using Domain.Entities;
    using Tests.Infrastructure;
    using Shouldly;
    using Xunit;

    public class CreateCustomerCommandTests : BaseTest<Customer>
    {
        [Trait(nameof(Customer), "CreateCustomer command tests")]
        [Fact(DisplayName = "Handle given valid request should create customer and return id")]
        public async Task Handle_GivenValidRequest_ShouldReturnCustomerId()
        {
            // Arrange
            var command = new CreateCustomerCommand
            {
                FirstName = "John",
                LastName = "Doe",
                Gender = "Male",
                PhoneNumber = "0885359164",
                Status = "Active",
            };
            var sut = new CreateCustomerCommandHandler(this.deletableEntityRepository);

            // Act
            var id = await sut.Handle(command, It.IsAny<CancellationToken>());

            // Assert
            var customer = await this.dbContext.Customers.SingleOrDefaultAsync(x => x.Id == id);
            customer.ShouldNotBeNull();
            customer.FirstName.ShouldBe("John");
            customer.LastName.ShouldBe("Doe");
            customer.Gender.ShouldBe("Male");
            customer.PhoneNumber.ShouldBe("0885359164");
            customer.Status.ShouldBe("Active");
        }

        [Trait(nameof(Customer), "CreateCustomer command tests")]
        [Fact(DisplayName = "Handle given null request should throw ArgumentNullException")]
        public async Task Handle_GivenNullRequest_ShouldThrowArgumentNullException()
        {
            // Arrange
            var sut = new CreateCustomerCommandHandler(this.deletableEntityRepository);

            // Act & Assert
            await Should.ThrowAsync<ArgumentNullException>(sut.Handle(null, It.IsAny<CancellationToken>()));
        }
    }
}