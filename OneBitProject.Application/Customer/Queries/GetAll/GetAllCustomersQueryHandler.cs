namespace OneBitProject.Application.Customer.Queries.GetAll
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using OneBitProject.Application.Common.Models;
    using OneBitProject.Application.Infrastructure.Automapper;
    using OneBitProject.Application.Interfaces;
    using OneBitProject.Domain.Entities;

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
                .To<CustomerLookupModel>()
                .ToListAsync(cancellationToken);

            return new GetAllCustomersViewModel
            {
                Customers = customers,
            };
        }
    }
}