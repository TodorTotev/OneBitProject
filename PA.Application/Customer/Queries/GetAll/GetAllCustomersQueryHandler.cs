using PA.Application.Common.Models;
using PA.Application.Interfaces;

namespace PA.Application.Customer.Queries.GetAll
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Application.Common.Models;
    using Application.Infrastructure.Automapper;
    using Application.Interfaces;
    using PA.Domain.Entities;

    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, GetAllCustomersViewModel>
    {
        private readonly IDeletableEntityRepository<Customer> customersRepository;

        public GetAllCustomersQueryHandler(IDeletableEntityRepository<Customer> customersRepository)
        {
            this.customersRepository = customersRepository;
        }

        public async Task<GetAllCustomersViewModel> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            request = request ?? throw new ArgumentNullException(nameof(Customer));

            var customers = await this.customersRepository
                .All()
                .Where(x => x.Status != "Deleted")
                .To<CustomerLookupModel>()
                .ToListAsync(cancellationToken);

            return new GetAllCustomersViewModel
            {
                Customers = customers,
            };
        }
    }
}