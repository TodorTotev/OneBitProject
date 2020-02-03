// ReSharper disable PossibleNullReferenceException

using PA.Tests.Infrastructure;

namespace PA.Tests.Order.Commands.Delete
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Application.Exceptions;
    using Application.Interfaces;
    using Application.Order.Commands.Delete;
    using Domain.Entities;
    using Tests.Infrastructure;
    using Shouldly;
    using Xunit;

    public class DeleteOrderCommandTests : BaseTest<Order>
    {
        [Trait(nameof(Order), "DeleteOrder command tests")]
        [Fact(DisplayName = "Handle given valid request should delete Order")]
        public async Task Handle_GivenValidRequest_ShouldDeleteOrder()
        {
            // Arrange
            var command = new DeleteOrderCommand { Id = 1 };
            var sut = new DeleteOrderCommandHandler(this.deletableEntityRepository);

            // Act
            var orderId = await sut.Handle(command, It.IsAny<CancellationToken>());

            // Assert
            orderId.ShouldBe(1);

            var modifiedOrder = await this.dbContext.Orders
                .SingleOrDefaultAsync(x => x.Id == orderId);
            modifiedOrder.IsDeleted.ShouldBe(true);
        }

        [Trait(nameof(Customer), "DeleteCustomer command tests")]
        [Fact(DisplayName = "Handle given invalid request should throw EntityAlreadyDeletedException")]
        public async Task Handle_GivenInvalidRequest_ShouldThrowFailedEntityAlreadyDeletedException()
        {
            // Arrange
            var command = new DeleteOrderCommand { Id = 2 };
            var sut = new DeleteOrderCommandHandler(this.deletableEntityRepository);

            var order = await this.deletableEntityRepository
                .GetByIdWithDeletedAsync(1);

            this.deletableEntityRepository.Delete(order);
            await this.deletableEntityRepository.SaveChangesAsync();

            // Act & Assert
            await Should.ThrowAsync<EntityAlreadyDeletedException>(sut.Handle(command, It.IsAny<CancellationToken>()));
        }

        [Trait(nameof(Customer), "DeleteCustomer command tests")]
        [Fact(DisplayName = "Handle given null request should throw ArgumentNullException")]
        public async Task Handle_GivenNullRequest_ShouldThrowArgumentNullException()
        {
            // Arrange
            var sut = new DeleteOrderCommandHandler(It.IsAny<IDeletableEntityRepository<Order>>());

            // Act & Assert
            await Should.ThrowAsync<ArgumentException>(sut.Handle(null, It.IsAny<CancellationToken>()));
        }

        [Trait(nameof(Customer), "DeleteCustomer command tests")]
        [Fact(DisplayName = "Handle given invalid request should throw NotFoundException")]
        public async Task Handle_GivenInvalidRequest_ShouldThrowNotFoundException()
        {
            // Arrange
            var command = new DeleteOrderCommand { Id = 133 };
            var sut = new DeleteOrderCommandHandler(this.deletableEntityRepository);

            // Act & Assert
            await Should.ThrowAsync<NotFoundException>(sut.Handle(command, It.IsAny<CancellationToken>()));
        }
    }
}