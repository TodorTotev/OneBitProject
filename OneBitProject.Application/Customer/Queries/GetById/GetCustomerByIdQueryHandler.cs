namespace OneBitProject.Application.Customer.Queries.GetById
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

    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerLookupModel>
    {
        private readonly IDeletableEntityRepository<Customer> customersRepository;

        public GetCustomerByIdQueryHandler(IDeletableEntityRepository<Customer> customersRepository)
        {
            this.customersRepository = customersRepository;
        }

        public async Task<CustomerLookupModel> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            var requestedEntity = await this.customersRepository
                                      .AllAsNoTracking()
                                      .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                  ?? throw new NotFoundException(nameof(Customer), request.Id);

            var customer = requestedEntity.To<CustomerLookupModel>();
            return customer;
        }
    }
}
