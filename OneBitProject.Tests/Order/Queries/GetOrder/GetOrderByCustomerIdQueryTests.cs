namespace OneBitProject.Tests.Order.Queries.GetOrder
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Moq;
    using OneBigProject.Persistence.Repositories;
    using OneBitProject.Application.Exceptions;
    using OneBitProject.Application.Order.Queries.GetOrder;
    using OneBitProject.Domain.Entities;
    using OneBitProject.Tests.Infrastructure;
    using Shouldly;
    using Xunit;

    public class GetOrderByCustomerIdQueryTests : BaseTest<Order>
    {
        [Trait(nameof(Order), "GetOrder query tests")]
        [Fact(DisplayName = "Handle given valid request should return view model")]
        public async Task Handle_GivenValidRequest_ShouldReturnViewModel()
        {
            // Arrange
            var query = new GetOrderByCustomerIdQuery { Id = 1 };
            var customersRepository = new EfDeletableEntityRepository<Customer>(this.dbContext);
            var sut = new GetOrderByCustomerIdQueryHandler(this.deletableEntityRepository, customersRepository);

            // Act
            var viewModel = await sut.Handle(query, It.IsAny<CancellationToken>());

            viewModel.ShouldNotBeNull();
            viewModel.ShouldBeOfType<GetAllOrdersViewModel>();
            viewModel.Orders.Count().ShouldBe(1);
        }

        [Trait(nameof(Order), "GetOrder query tests")]
        [Fact(DisplayName = "Handle given null request should throw ArgumentNullException")]
        public async Task Handle_GivenNullRequest_ShouldThrowArgumentNullException()
        {
            // Arrange
            var sut = new GetOrderByCustomerIdQueryHandler(
                this.deletableEntityRepository,
                It.IsAny<EfDeletableEntityRepository<Customer>>());

            // Act & assert
            await Should.ThrowAsync<ArgumentNullException>(sut.Handle(null, It.IsAny<CancellationToken>()));
        }

        [Trait(nameof(Order), "GetOrder query tests")]
        [Fact(DisplayName = "Handle given invalid request should throw NotFoundException")]
        public async Task Handle_GivenInvalidRequest_ShouldThrowNotFoundException()
        {
            // Arrange
            var query = new GetOrderByCustomerIdQuery {Id = 500};
            var customersRepository = new EfDeletableEntityRepository<Customer>(this.dbContext);
            var sut = new GetOrderByCustomerIdQueryHandler(this.deletableEntityRepository, customersRepository);

            // Act & Assert
            await Should.ThrowAsync<NotFoundException>(sut.Handle(query, It.IsAny<CancellationToken>()));
        }
    }
}