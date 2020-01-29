namespace OneBitProject.Application.Order.Commands.Update
{
    using MediatR;

    public class UpdateOrderCommand : IRequest<int>
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Price { get; set; }

        public string Status { get; set; }

        public double TotalAmount { get; set; }

        public string Quantity { get; set; }
    }
}
