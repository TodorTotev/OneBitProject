using PA.Application.Common.Models;

namespace PA.Application.Order.Queries.GetOrder
{
    using System.Collections.Generic;

    using Application.Common.Models;

    public class GetAllOrdersViewModel
    {
        public IEnumerable<OrderLookupModel> Orders { get; set; }
    }
}
