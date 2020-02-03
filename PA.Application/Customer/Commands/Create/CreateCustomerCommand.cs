using PA.Application.Interfaces.Mapping;

namespace PA.Application.Customer.Commands.Create
{
    using MediatR;
    using Application.Interfaces.Mapping;
    using PA.Domain.Entities;

    public class CreateCustomerCommand : IRequest<int>, IMapTo<Customer>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string Status { get; set; }
    }
}
