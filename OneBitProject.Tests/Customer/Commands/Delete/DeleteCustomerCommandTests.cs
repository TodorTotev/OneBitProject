// ReSharper disable PossibleNullReferenceException

namespace OneBitProject.Tests.Customer.Commands.Delete
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using OneBitProject.Application.Customer.Commands.Delete;
    using OneBitProject.Application.Exceptions;
    using OneBitProject.Application.Interfaces;
    using OneBitProject.Domain.Entities;
    using OneBitProject.Tests.Infrastructure;
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
            var categoryId = await sut.Handle(command, It.IsAny<CancellationToken>());

            // Assert
            categoryId.ShouldBe(1);

            var modifiedCategory = await this.dbContext.Customers
                .SingleOrDefaultAsync(x => x.Id == categoryId);
            modifiedCategory.IsDeleted.ShouldBe(true);
        }

        [Trait(nameof(Customer), "DeleteCustomer command tests")]
        [Fact(DisplayName = "Handle given invalid request should throw EntityAlreadyDeletedException")]
        public async Task Handle_GivenInvalidRequest_ShouldThrowFailedEntityAlreadyDeletedException()
        {
            // Arrange
            var command = new DeleteCustomerCommand { Id = 2 };
            var sut = new DeleteCustomerCommandHandler(this.deletableEntityRepository);

            var category = await this.deletableEntityRepository
                .GetByIdWithDeletedAsync(1);

            this.deletableEntityRepository.Delete(category);
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