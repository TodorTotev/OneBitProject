using PA.Application.Interfaces;

namespace PA.Application.Order.Commands.Create
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;
    using Application.Interfaces;

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IDeletableEntityRepository<PA.Domain.Entities.Order> ordersRepository;
        private readonly IDeletableEntityRepository<PA.Domain.Entities.Customer> customersRepository;

        public CreateOrderCommandHandler(
            IDeletableEntityRepository<PA.Domain.Entities.Order> ordersRepository,
            IDeletableEntityRepository<PA.Domain.Entities.Customer> customersRepository)
        {
            this.ordersRepository = ordersRepository;
            this.customersRepository = customersRepository;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));
            

            var order = new PA.Domain.Entities.Order
            {
                Description = request.Description,
                Quantity = int.Parse(request.Quantity),
                Status = request.Status,
                Price = double.Parse(request.Price),
                TotalAmount = int.Parse(request.Quantity) * double.Parse(request.Price),
                CustomerId = int.Parse(request.CustomerId),
            };

            await this.ordersRepository.AddAsync(order);
            await this.ordersRepository.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
