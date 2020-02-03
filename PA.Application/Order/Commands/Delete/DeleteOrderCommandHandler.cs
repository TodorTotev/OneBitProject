using PA.Application.Exceptions;
using PA.Application.Interfaces;

namespace PA.Application.Order.Commands.Delete
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Application.Exceptions;
    using Application.Interfaces;
    using PA.Domain.Entities;

    using static PA.Common.GlobalConstants;

    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, int>
    {
        private readonly IDeletableEntityRepository<Order> ordersRepository;

        public DeleteOrderCommandHandler(IDeletableEntityRepository<Order> ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public async Task<int> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            var order = await this.ordersRepository
                            .AllWithDeleted()
                            .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                        ?? throw new NotFoundException(nameof(Order), request.Id);

            if (order.IsDeleted)
            {
                throw new EntityAlreadyDeletedException(nameof(Customer), request.Id, EntityAlreadyDeletedMessage);
            }

            order.IsDeleted = true;
            order.Status = "Deleted";

            this.ordersRepository.Update(order);
            await this.ordersRepository.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
