using PA.Tests.Infrastructure;

namespace PA.Tests.Order.Queries.GetOrderById
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Moq;
    using Application.Common.Models;
    using Application.Exceptions;
    using Application.Order.Queries.GetById;
    using Tests.Infrastructure;
    using Shouldly;
    using Xunit;

    public class GetOrderByIdQueryTests : BaseTest<Domain.Entities.Order>
    {
        [Trait(nameof(Domain.Entities.Order), "GetOrderById query tests")]
        [Fact(DisplayName = "Handle given valid request should return OrderLookupModel")]
        public async Task Handle_GivenValidRequest_ShouldReturnOrderLookUpModel()
        {
            // Arrange
            var query = new GetOrderByIdQuery { Id = 1 };
            var sut = new GetOrderByIdQueryHandler(this.deletableEntityRepository);

            // Act
            var order = await sut.Handle(query, It.IsAny<CancellationToken>());

            order.ShouldNotBeNull();
            order.ShouldBeOfType<OrderLookupModel>();
            order.Description.ShouldBe("John");
        }

        [Trait(nameof(Domain.Entities.Order), "GetOrderById query tests")]
        [Fact(DisplayName = "Handle given invalid request should throw NotFoundException")]
        public async Task Handle_GivenInvalidRequest_ShouldThrowNotFoundException()
        {
            // Arrange
            var query = new GetOrderByIdQuery { Id = 1000 };
            var sut = new GetOrderByIdQueryHandler(this.deletableEntityRepository);

            // Act & Assert
            await Should.ThrowAsync<NotFoundException>(sut.Handle(query, It.IsAny<CancellationToken>()));
        }

        [Trait(nameof(Domain.Entities.Order), "GetOrderById query tests")]
        [Fact(DisplayName = "Handle given null request should throw ArgumentNullException")]
        public async Task Handle_GivenNullRequest_ShouldTurnArgumentNullException()
        {
            // Arrange
            var sut = new GetOrderByIdQueryHandler(this.deletableEntityRepository);

            // Act & Assert
            await Should.ThrowAsync<ArgumentNullException>(sut.Handle(null, It.IsAny<CancellationToken>()));
        }
    }
}