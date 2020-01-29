namespace OneBitProject.Application.Order.Commands.Update
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using OneBitProject.Application.Exceptions;
    using OneBitProject.Application.Interfaces;
    using OneBitProject.Domain.Entities;

    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, int>
    {
        private readonly IDeletableEntityRepository<Order> ordersRepository;

        public UpdateOrderCommandHandler(IDeletableEntityRepository<Order> ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public async Task<int> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            var order = await this.ordersRepository
                            .All()
                            .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken)
                        ?? throw new NotFoundException(nameof(Order), request.Id);

            order.Description = request.Description;
            order.TotalAmount = request.TotalAmount;
            order.Quantity = request.Quantity;
            order.Status = request.Status;

            this.ordersRepository.Update(order);
            await this.ordersRepository.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
