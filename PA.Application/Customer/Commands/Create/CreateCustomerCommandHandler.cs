using PA.Application.Interfaces;

namespace PA.Application.Customer.Commands.Create
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;
    using Application.Infrastructure.Automapper;
    using Application.Interfaces;
    using PA.Domain.Entities;

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly IDeletableEntityRepository<Customer> customersRepository;

        public CreateCustomerCommandHandler(IDeletableEntityRepository<Customer> customersRepository)
        {
            this.customersRepository = customersRepository;
        }

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            var customer = request.To<Customer>();

            await this.customersRepository.AddAsync(customer);
            await this.customersRepository.SaveChangesAsync(cancellationToken);

            return customer.Id;
        }
    }
}
