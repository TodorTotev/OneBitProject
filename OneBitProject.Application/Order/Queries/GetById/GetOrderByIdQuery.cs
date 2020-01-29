namespace OneBitProject.Application.Order.Queries.GetById
{
    using MediatR;
    using OneBitProject.Application.Common.Models;

    public class GetOrderByIdQuery : IRequest<OrderLookupModel>
    {
        public int Id { get; set; }
    }
}