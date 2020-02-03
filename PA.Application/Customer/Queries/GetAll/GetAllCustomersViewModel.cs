using PA.Application.Common.Models;

namespace PA.Application.Customer.Queries.GetAll
{
    using System.Collections.Generic;

    using Application.Common.Models;

    public class GetAllCustomersViewModel
    {
        public IEnumerable<CustomerLookupModel> Customers { get; set; }
    }
}