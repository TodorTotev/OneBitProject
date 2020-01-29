namespace OneBitProject.Application.Common.Models
{
    using OneBitProject.Application.Interfaces.Mapping;
    using OneBitProject.Domain.Entities;

    public class OrderLookupModel : IMapFrom<Order>
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public double TotalAmount { get; set; }

        public string Status { get; set; }
    }
}
