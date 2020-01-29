namespace OneBitProject.Application.Order.Queries.GetById
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using OneBitProject.Application.Common.Models;
    using OneBitProject.Application.Exceptions;
    using OneBitProject.Application.Infrastructure.Automapper;
    using OneBitProject.Application.Interfaces;
    using OneBitProject.Domain.Entities;

    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderLookupModel>
    {
        private readonly IDeletableEntityRepository<Order> ordersRepository;

        public GetOrderByIdQueryHandler(IDeletableEntityRepository<Order> ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public async Task<OrderLookupModel> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            var order = await this.ordersRepository
                            .All()
                            .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                        ?? throw new NotFoundException(nameof(request), request.Id);

            return order.To<OrderLookupModel>();
        }
    }
}