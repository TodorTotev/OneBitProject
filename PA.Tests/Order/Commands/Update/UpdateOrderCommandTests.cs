using PA.Tests.Infrastructure;

namespace PA.Tests.Order.Commands.Update
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Application.Exceptions;
    using Application.Order.Commands.Update;
    using Tests.Infrastructure;
    using Shouldly;
    using Xunit;

    public class UpdateOrderCommandTests : BaseTest<Domain.Entities.Order>
    {
        [Trait(nameof(Order), "UpdateOrder command tests")]
        [Fact(DisplayName = "Handle given valid request should update Order and return id")]
        public async Task Handle_GivenValidRequest_ShouldReturnOrderId()
        {
            // Arrange
            var command = new UpdateOrderCommand
            {
                Id = 1,
                Description = "NewDesc",
                Quantity = "321",
                Status = "Tested",
            };

            var sut = new UpdateOrderCommandHandler(this.deletableEntityRepository);

            // Act
            var id = await sut.Handle(command, It.IsAny<CancellationToken>());

            // Assert
            var order = await this.dbContext.Orders.SingleOrDefaultAsync(x => x.Id == id);
            order.ShouldNotBeNull();
            order.Description.ShouldBe("NewDesc");
            order.Quantity.ShouldBe(321);
            order.Status.ShouldBe("Tested");
        }

        [Trait(nameof(Order), "UpdateOrder command tests")]
        [Fact(DisplayName = "Handle given null request should throw ArgumentNullException")]
        public async Task Handle_GivenNullRequest_ShouldThrowArgumentNullException()
        {
            // Arrange
            var sut = new UpdateOrderCommandHandler(this.deletableEntityRepository);

            // Act & Assert
            await Should.ThrowAsync<ArgumentNullException>(sut.Handle(null, It.IsAny<CancellationToken>()));
        }

        [Trait(nameof(Order), "UpdateOrder command tests")]
        [Fact(DisplayName = "Handle given invalid request should throw NotFoundException")]
        public async Task Handle_GivenInvalidRequest_ShouldThrowNotFoundException()
        {
            // Arrange
            var command = new UpdateOrderCommand
            {
                Id = 500,
                Description = "NewDesc",
                Quantity = "321",
                Price = "123",
                Status = "Tested",
            };

            var sut = new UpdateOrderCommandHandler(this.deletableEntityRepository);

            // Act & Assert
            await Should.ThrowAsync<NotFoundException>(sut.Handle(command, It.IsAny<CancellationToken>()));
        }
    }
}