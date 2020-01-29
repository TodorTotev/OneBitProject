namespace OneBitProject.Application.Order.Commands.Create
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;
    using OneBitProject.Application.Interfaces;

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IDeletableEntityRepository<Domain.Entities.Order> ordersRepository;
        private readonly IDeletableEntityRepository<Domain.Entities.Customer> customersRepository;

        public CreateOrderCommandHandler(
            IDeletableEntityRepository<Domain.Entities.Order> ordersRepository,
            IDeletableEntityRepository<Domain.Entities.Customer> customersRepository)
        {
            this.ordersRepository = ordersRepository;
            this.customersRepository = customersRepository;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));
            

            var order = new Domain.Entities.Order
            {
                Description = request.Description,
                Quantity = int.Parse(request.Quantity),
                Status = request.Status,
                TotalAmount = int.Parse(request.Quantity) * double.Parse(request.Price),
                CustomerId = int.Parse(request.CustomerId),
            };

            await this.ordersRepository.AddAsync(order);
            await this.ordersRepository.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
