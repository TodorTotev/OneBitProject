using PA.Application.Common.Models;

namespace PA.Application.Customer.Queries.GetById
{
    using MediatR;
    using Application.Common.Models;

    public class GetCustomerByIdQuery : IRequest<CustomerLookupModel>
    {
        public int Id { get; set; }
    }
}
