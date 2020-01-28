namespace OneBitProject.Domain.Entities
{
    using OneBitProject.Domain.Infrastructure;

    public class Order : BaseDeletableModel<int>
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public double TotalAmount { get; set; }

        public string Status { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
