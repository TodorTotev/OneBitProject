using PA.Domain.Infrastructure;

namespace PA.Domain.Entities
{
    using System.Collections.Generic;

    using Domain.Infrastructure;

    public class Customer : BaseDeletableModel<int>
    {
        public Customer()
        {
            this.Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string Status { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
