namespace PA.Tests.Infrastructure
{
    using System;
    using MediatR;
    using Moq;
    using Persistence;
    using Persistence.Repositories;
    using Application.Interfaces;
    using Domain.Infrastructure;

    // ReSharper disable SA1401
    public abstract class BaseTest<T> : IDisposable
        where T : class, IDeletableEntity, new()
    {
        protected readonly ApplicationDbContext dbContext;
        protected readonly Mock<IMediator> mediatorMock;
        protected readonly IDeletableEntityRepository<T> deletableEntityRepository;

        protected BaseTest()
        {
            this.dbContext = ApplicationDbContextFactory.Create();
            this.deletableEntityRepository = new EfDeletableEntityRepository<T>(this.dbContext);
            this.mediatorMock = new Mock<IMediator>();

            MapperInitializer.InitializeMapper();
        }

        public void Dispose()
        {
            ApplicationDbContextFactory.Destroy(this.dbContext);
            this.deletableEntityRepository.Dispose();
        }
    }
}