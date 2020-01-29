namespace OneBitProject.Application.Order.Commands.Create
{
    using MediatR;

    public class CreateOrderCommand : IRequest<int>
    {
        public string Description { get; set; }

        public int Quantity { get; set; }

        public double TotalAmount { get; set; }

        public string Status { get; set; }

        public int CustomerId { get; set; }
    }
}