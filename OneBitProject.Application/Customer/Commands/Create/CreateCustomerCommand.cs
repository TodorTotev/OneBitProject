namespace OneBitProject.Application.Customer.Commands.Create
{
    using MediatR;

    public class CreateCustomerCommand : IRequest<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string Status { get; set; }
    }
}
