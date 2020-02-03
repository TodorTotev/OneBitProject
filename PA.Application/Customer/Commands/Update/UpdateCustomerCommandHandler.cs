using PA.Application.Exceptions;
using PA.Application.Interfaces;

namespace PA.Application.Customer.Commands.Update
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Application.Exceptions;
    using Application.Interfaces;
    using PA.Domain.Entities;

    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, int>
    {
        private readonly IDeletableEntityRepository<Customer> customersRepository;

        public UpdateCustomerCommandHandler(IDeletableEntityRepository<Customer> customersRepository)
        {
            this.customersRepository = customersRepository;
        }

        public async Task<int> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            var customer = await this.customersRepository
                               .All()
                               .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken)
                           ?? throw new NotFoundException(nameof(Customer), request.Id);

            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
            customer.Gender = request.Gender;
            customer.PhoneNumber = request.PhoneNumber;
            customer.Status = request.Status;

            this.customersRepository.Update(customer);
            await this.customersRepository.SaveChangesAsync(cancellationToken);

            return customer.Id;
        }
    }
}
