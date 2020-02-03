using PA.Tests.Infrastructure;

namespace PA.Tests.Customer.Queries.GetById
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Moq;
    using Application.Common.Models;
    using Application.Customer.Queries.GetById;
    using Application.Exceptions;
    using Tests.Infrastructure;
    using Shouldly;
    using Xunit;

    public class GetCustomerByIdQueryTests : BaseTest<Domain.Entities.Customer>
    {
        [Trait(nameof(Domain.Entities.Customer), "GetCustomerById query tests")]
        [Fact(DisplayName = "Handle given valid request should return CustomerLookupModel")]
        public async Task Handle_GivenValidRequest_ShouldReturnEditMainCategoryCommand()
        {
            // Arrange
            var query = new GetCustomerByIdQuery { Id = 1 };
            var sut = new GetCustomerByIdQueryHandler(this.deletableEntityRepository);

            // Act
            var customer = await sut.Handle(query, It.IsAny<CancellationToken>());

            customer.ShouldNotBeNull();
            customer.ShouldBeOfType<CustomerLookupModel>();
            customer.FirstName.ShouldBe("John");
        }

        [Trait(nameof(Domain.Entities.Customer), "GetCustomerById query tests")]
        [Fact(DisplayName = "Handle given invalid request should throw NotFoundException")]
        public async Task Handle_GivenInvalidRequest_ShouldThrowNotFoundException()
        {
            // Arrange
            var query = new GetCustomerByIdQuery { Id = 1000 };
            var sut = new GetCustomerByIdQueryHandler(this.deletableEntityRepository);

            // Act & Assert
            await Should.ThrowAsync<NotFoundException>(sut.Handle(query, It.IsAny<CancellationToken>()));
        }

        [Trait(nameof(Domain.Entities.Customer), "GetCustomerById query tests")]
        [Fact(DisplayName = "Handle given null request should throw ArgumentNullException")]
        public async Task Handle_GivenNullRequest_ShouldTurnArgumentNullException()
        {
            // Arrange
            var sut = new GetCustomerByIdQueryHandler(this.deletableEntityRepository);

            // Act & Assert
            await Should.ThrowAsync<ArgumentNullException>(sut.Handle(null, It.IsAny<CancellationToken>()));
        }
    }
}