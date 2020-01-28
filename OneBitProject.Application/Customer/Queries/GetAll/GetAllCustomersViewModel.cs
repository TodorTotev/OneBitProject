namespace OneBitProject.Application.Customer.Queries.GetAll
{
    using System.Collections.Generic;

    using OneBitProject.Application.Common.Models;

    public class GetAllCustomersViewModel
    {
        public IEnumerable<CustomerLookupModel> Customers { get; set; }
    }
}