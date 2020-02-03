using PA.Application.Common.Models;
using PA.Application.Exceptions;
using PA.Application.Interfaces;

namespace PA.Application.Order.Queries.GetById
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Application.Common.Models;
    using Application.Exceptions;
    using Application.Infrastructure.Automapper;
    using Application.Interfaces;
    using PA.Domain.Entities;

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