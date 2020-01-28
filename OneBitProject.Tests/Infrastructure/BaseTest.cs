namespace OneBitProject.Tests.Infrastructure
{
    using System;
    using MediatR;
    using Moq;
    using OneBigProject.Persistence;
    using OneBigProject.Persistence.Repositories;
    using OneBitProject.Application.Interfaces;
    using OneBitProject.Domain.Infrastructure;

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