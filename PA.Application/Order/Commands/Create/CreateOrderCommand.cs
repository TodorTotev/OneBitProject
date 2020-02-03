namespace PA.Application.Order.Commands.Create
{
    using MediatR;

    public class CreateOrderCommand : IRequest<int>
    {
        public string Description { get; set; }

        public string Quantity { get; set; }

        public string Price { get; set; }

        public string Status { get; set; }

        public string CustomerId { get; set; }
    }
}
