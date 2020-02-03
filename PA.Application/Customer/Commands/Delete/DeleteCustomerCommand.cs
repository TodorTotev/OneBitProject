namespace PA.Application.Customer.Commands.Delete
{
    using MediatR;

    public class DeleteCustomerCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}