using PA.Application.Common.Models;

namespace PA.Application.Order.Queries.GetById
{
    using MediatR;
    using Application.Common.Models;

    public class GetOrderByIdQuery : IRequest<OrderLookupModel>
    {
        public int Id { get; set; }
    }
}