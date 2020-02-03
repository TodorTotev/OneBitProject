using PA.Tests.Infrastructure;

namespace PA.Tests.Customer.Commands.Update
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Application.Customer.Commands.Update;
    using Application.Exceptions;
    using Domain.Entities;
    using Tests.Infrastructure;
    using Shouldly;
    using Xunit;

    public class UpdateCustomerCommandTests : BaseTest<Customer>
    {
        [Trait(nameof(Customer), "UpdateCustomer command tests")]
        [Fact(DisplayName = "Handle given valid request should update customer and return id")]
        public async Task Handle_GivenValidRequest_ShouldReturnCustomerId()
        {
            // Arrange
            var command = new UpdateCustomerCommand
            {
                Id = 1,
                FirstName = "Gosho",
                LastName = "Petkov",
                Gender = "Female",
                PhoneNumber = "12345",
                Status = "Inactive"
            };

            var sut = new UpdateCustomerCommandHandler(this.deletableEntityRepository);

            // Act
            var id = await sut.Handle(command, It.IsAny<CancellationToken>());

            // Assert
            var customer = await this.dbContext.Customers.SingleOrDefaultAsync(x => x.Id == id);
            customer.ShouldNotBeNull();
            customer.FirstName.ShouldBe("Gosho");
            customer.LastName.ShouldBe("Petkov");
            customer.Gender.ShouldBe("Female");
            customer.PhoneNumber.ShouldBe("12345");
            customer.Status.ShouldBe("Inactive");
        }

        [Trait(nameof(Customer), "CreateCustomer command tests")]
        [Fact(DisplayName = "Handle given null request should throw ArgumentNullException")]
        public async Task Handle_GivenNullRequest_ShouldThrowArgumentNullException()
        {
            // Arrange
            var sut = new UpdateCustomerCommandHandler(this.deletableEntityRepository);

            // Act & Assert
            await Should.ThrowAsync<ArgumentNullException>(sut.Handle(null, It.IsAny<CancellationToken>()));
        }

        [Trait(nameof(Customer), "UpdateCustomer command tests")]
        [Fact(DisplayName = "Handle given invalid request should throw NotFoundException")]
        public async Task Handle_GivenInvalidRequest_ShouldThrowNotFoundException()
        {
            // Arrange
            var command = new UpdateCustomerCommand
            {
                Id = 5,
                FirstName = "Gosho",
                LastName = "Petkov",
                Gender = "Female",
                PhoneNumber = "12345",
                Status = "Inactive"
            };

            var sut = new UpdateCustomerCommandHandler(this.deletableEntityRepository);

            // Act & Assert
            await Should.ThrowAsync<NotFoundException>(sut.Handle(command, It.IsAny<CancellationToken>()));
        }
    }
}