using MediatR;

namespace PA.Application.Order.Queries.GetOrder
{
    public class GetOrderByCustomerIdQuery : IRequest<GetAllOrdersViewModel>
    {
        public int Id { get; set; }
    }
}
