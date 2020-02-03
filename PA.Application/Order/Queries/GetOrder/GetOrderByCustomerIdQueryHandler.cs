using PA.Application.Common.Models;
using PA.Application.Exceptions;
using PA.Application.Interfaces;

namespace PA.Application.Order.Queries.GetOrder
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Application.Common.Models;
    using Application.Exceptions;
    using Application.Infrastructure.Automapper;
    using Application.Interfaces;
    using PA.Domain.Entities;

    public class GetOrderByCustomerIdQueryHandler : IRequestHandler<GetOrderByCustomerIdQuery, GetAllOrdersViewModel>
    {
        private readonly IDeletableEntityRepository<Order> ordersRepository;
        private readonly IDeletableEntityRepository<Customer> customersRepository;

        public GetOrderByCustomerIdQueryHandler(
            IDeletableEntityRepository<Order> ordersRepository,
            IDeletableEntityRepository<Customer> customersRepository)
        {
            this.ordersRepository = ordersRepository;
            this.customersRepository = customersRepository;
        }

        public async Task<GetAllOrdersViewModel> Handle(
            GetOrderByCustomerIdQuery request,
            CancellationToken cancellationToken)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            var customer = await this.customersRepository
                               .All()
                               .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken)
                           ?? throw new NotFoundException(nameof(Customer), request.Id);

            var orders = await this.ordersRepository
                .All()
                .Where(x => x.CustomerId == customer.Id)
                .To<OrderLookupModel>()
                .ToListAsync(cancellationToken);

            return new GetAllOrdersViewModel
            {
                Orders = orders,
            };
        }
    }
}