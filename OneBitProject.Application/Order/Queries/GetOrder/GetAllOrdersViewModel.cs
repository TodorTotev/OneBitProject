namespace OneBitProject.Application.Order.Queries.GetOrder
{
    using System.Collections.Generic;

    using OneBitProject.Application.Common.Models;

    public class GetAllOrdersViewModel
    {
        public IEnumerable<OrderLookupModel> Orders { get; set; }
    }
}
