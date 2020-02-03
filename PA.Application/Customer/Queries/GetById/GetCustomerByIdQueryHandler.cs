using PA.Application.Common.Models;
using PA.Application.Exceptions;
using PA.Application.Interfaces;

namespace PA.Application.Customer.Queries.GetById
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
