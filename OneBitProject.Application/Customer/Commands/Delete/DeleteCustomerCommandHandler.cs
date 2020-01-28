namespace OneBitProject.Application.Customer.Commands.Delete
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using OneBitProject.Application.Exceptions;
    using OneBitProject.Application.Interfaces;
    using OneBitProject.Domain.Entities;

    using static OneBitProject.Common.GlobalConstants;

    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, int>
    {
        private readonly IDeletableEntityRepository<Customer> customersRepository;

        public DeleteCustomerCommandHandler(IDeletableEntityRepository<Customer> customersRepository)
        {
            this.customersRepository = customersRepository;
        }

        public async Task<int> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            var customer = await this.customersRepository
                               .AllWithDeleted()
                               .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                           ?? throw new NotFoundException(nameof(Customer), request.Id);

            if (customer.IsDeleted)
            {
                throw new EntityAlreadyDeletedException(nameof(Customer), request.Id, EntityAlreadyDeletedMessage);
            }

            this.customersRepository.Delete(customer);
            await this.customersRepository.SaveChangesAsync(cancellationToken);

            return customer.Id;
        }
    }
}