using PA.Domain.Infrastructure;

namespace PA.Domain.Entities
{
    using Domain.Infrastructure;

    public class Order : BaseDeletableModel<int>
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public double TotalAmount { get; set; }

        public string Status { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
