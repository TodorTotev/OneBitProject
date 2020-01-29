namespace OneBitProject.Application.Customer.Queries.GetById
{
    using MediatR;
    using OneBitProject.Application.Common.Models;

    public class GetCustomerByIdQuery : IRequest<CustomerLookupModel>
    {
        public int Id { get; set; }
    }
}
