using PA.Application.Interfaces.Mapping;

namespace PA.Application.Common.Models
{
    using Application.Interfaces.Mapping;
    using PA.Domain.Entities;

    public class OrderLookupModel : IMapFrom<Order>
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public double TotalAmount { get; set; }
        
        public double Price { get; set; }

        public string Status { get; set; }

        public string CreatedOn { get; set; }
    }
}
