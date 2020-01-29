namespace OneBitProject.Tests.Order.Commands.Create
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Moq;
    using OneBigProject.Persistence.Repositories;
    using OneBitProject.Application.Exceptions;
    using OneBitProject.Application.Order.Commands.Create;
    using OneBitProject.Domain.Entities;
    using OneBitProject.Tests.Infrastructure;
    using Shouldly;
    using Xunit;

    public class CreateOrderCommandTests : BaseTest<Order>
    {
        [Trait(nameof(Order), "Create order command tests")]
        [Fact(DisplayName = "Handle given valid request should create order")]
        public async Task Handle_GivenValidRequest_ShouldCreateOrder()
        {
            // Arrange
            var command = new CreateOrderCommand
            {
                Description = "Desc",
                Price = 123,
                Quantity = 1,
                CustomerId = 1,
                Status = "Active",
            };

            var customersRepository = new EfDeletableEntityRepository<Customer>(this.dbContext);
            var sut = new CreateOrderCommandHandler(
                this.deletableEntityRepository,
                customersRepository);

            // Act
            var id = await sut.Handle(command, It.IsAny<CancellationToken>());

            // Assert
            var createdOrder = this.deletableEntityRepository
                .AllAsNoTracking()
                .SingleOrDefault(x => x.Description == "Desc");

            createdOrder.CustomerId.ShouldBe(1);
            createdOrder.Description.ShouldBe("Desc");
            createdOrder.TotalAmount.ShouldBe(123);
        }

        [Trait(nameof(Order), "Create order command tests")]
        [Fact(DisplayName = "Handle given null request should throw ArgumentNullException")]
        public async Task Handle_GivenNullRequest_ShouldThrowArgumentNullException()
        {
            // Arrange
            var sut = new CreateOrderCommandHandler(
                this.deletableEntityRepository,
                It.IsAny<EfDeletableEntityRepository<Customer>>());

            // Act & Assert
            await Should.ThrowAsync<ArgumentNullException>(sut.Handle(null, It.IsAny<CancellationToken>()));
        }

        [Trait(nameof(Order), "Create order command tests")]
        [Fact(DisplayName = "Handle given valid request should throw NotFoundException")]
        public async Task Handle_GivenInvalidRequest_ShouldThrowNotFoundException()
        {
            // Arrange
            var command = new CreateOrderCommand
            {
                Description = "Desc",
                Quantity = 123,
                CustomerId = 10,
                Status = "Active",
            };

            var customersRepository = new EfDeletableEntityRepository<Customer>(this.dbContext);
            var sut = new CreateOrderCommandHandler(
                this.deletableEntityRepository,
                customersRepository);

            // Act & Assert
            await Should.ThrowAsync<NotFoundException>(sut.Handle(command, It.IsAny<CancellationToken>()));
        }
    }
}