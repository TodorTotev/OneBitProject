using PA.Tests.Infrastructure;

namespace PA.Tests.Customer.Queries.GetAll
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Moq;
    using Application.Customer.Queries.GetAll;
    using Tests.Infrastructure;
    using Shouldly;
    using Xunit;

    public class GetAllCustomersQueryTests : BaseTest<Domain.Entities.Customer>
    {
        [Trait(nameof(Domain.Entities.Customer), "GetAllCustomers query tests")]
        [Fact(DisplayName = "Handle given valid request should return view model")]
        public async Task Handle_GivenValidRequest_ShouldReturnViewModel()
        {
            // Arrange
            var query = new GetAllCustomersQuery();
            var sut = new GetAllCustomersQueryHandler(this.deletableEntityRepository);

            // Act
            var viewModel = await sut.Handle(query, It.IsAny<CancellationToken>());

            viewModel.ShouldNotBeNull();
            viewModel.ShouldBeOfType<GetAllCustomersViewModel>();
            viewModel.Customers.Count().ShouldBe(1);
        }

        [Trait(nameof(Domain.Entities.Customer), "GetAllCustomers query tests")]
        [Fact(DisplayName = "Handle given null request should throw ArgumentNullException")]
        public async Task Handle_GivenNullRequest_ShouldThrowArgumentNullException()
        {
            // Arrange
            var sut = new GetAllCustomersQueryHandler(this.deletableEntityRepository);

            // Act & assert
            await Should.ThrowAsync<ArgumentNullException>(sut.Handle(null, It.IsAny<CancellationToken>()));
        }
    }
}