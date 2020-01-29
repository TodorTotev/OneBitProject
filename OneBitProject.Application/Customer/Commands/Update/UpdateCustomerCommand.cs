namespace OneBitProject.Application.Customer.Commands.Update
{
    using MediatR;

    public class UpdateCustomerCommand : IRequest<int>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string Status { get; set; }
    }
}
