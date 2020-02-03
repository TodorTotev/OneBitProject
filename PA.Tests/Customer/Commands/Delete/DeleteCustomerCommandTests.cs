// ReSharper disable PossibleNullReferenceException

using PA.Tests.Infrastructure;

namespace PA.Tests.Customer.Commands.Delete
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Application.Customer.Commands.Delete;
    using Application.Exceptions;
    using Application.Interfaces;
    using Domain.Entities;
    using Tests.Infrastructure;
    using Shouldly;
    using Xunit;

    public class DeleteCustomerCommandTests : BaseTest<Customer>
    {
        [Trait(nameof(Customer), "DeleteCustomer command tests")]
        [Fact(DisplayName = "Handle given valid request should delete Customer")]
        public async Task Handle_GivenValidRequest_ShouldDeleteCustomer()
        {
            // Arrange
            var command = new DeleteCustomerCommand { Id = 1 };
            var sut = new DeleteCustomerCommandHandler(this.deletableEntityRepository);

            // Act
            var customerId = await sut.Handle(command, It.IsAny<CancellationToken>());

            // Assert
            customerId.ShouldBe(1);

            var modifiedCustomer = await this.dbContext.Customers
                .SingleOrDefaultAsync(x => x.Id == customerId);
            modifiedCustomer.IsDeleted.ShouldBe(true);
        }

        [Trait(nameof(Customer), "DeleteCustomer command tests")]
        [Fact(DisplayName = "Handle given invalid request should throw EntityAlreadyDeletedException")]
        public async Task Handle_GivenInvalidRequest_ShouldThrowFailedEntityAlreadyDeletedException()
        {
            // Arrange
            var command = new DeleteCustomerCommand { Id = 2 };
            var sut = new DeleteCustomerCommandHandler(this.deletableEntityRepository);

            var customer = await this.deletableEntityRepository
                .GetByIdWithDeletedAsync(1);

            this.deletableEntityRepository.Delete(customer);
            await this.deletableEntityRepository.SaveChangesAsync();

            // Act & Assert
            await Should.ThrowAsync<EntityAlreadyDeletedException>(sut.Handle(command, It.IsAny<CancellationToken>()));
        }

        [Trait(nameof(Customer), "DeleteCustomer command tests")]
        [Fact(DisplayName = "Handle given null request should throw ArgumentNullException")]
        public async Task Handle_GivenNullRequest_ShouldThrowArgumentNullException()
        {
            // Arrange
            var sut = new DeleteCustomerCommandHandler(It.IsAny<IDeletableEntityRepository<Customer>>());

            // Act & Assert
            await Should.ThrowAsync<ArgumentException>(sut.Handle(null, It.IsAny<CancellationToken>()));
        }

        [Trait(nameof(Customer), "DeleteCustomer command tests")]
        [Fact(DisplayName = "Handle given invalid request should throw NotFoundException")]
        public async Task Handle_GivenInvalidRequest_ShouldThrowNotFoundException()
        {
            // Arrange
            var command = new DeleteCustomerCommand { Id = 133 };
            var sut = new DeleteCustomerCommandHandler(this.deletableEntityRepository);

            // Act & Assert
            await Should.ThrowAsync<NotFoundException>(sut.Handle(command, It.IsAny<CancellationToken>()));
        }
    }
}