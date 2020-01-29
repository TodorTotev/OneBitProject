namespace OneBitProject.Application.Order.Queries.GetOrder
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using OneBitProject.Application.Common.Models;
    using OneBitProject.Application.Exceptions;
    using OneBitProject.Application.Infrastructure.Automapper;
    using OneBitProject.Application.Interfaces;
    using OneBitProject.Domain.Entities;

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