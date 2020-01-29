namespace OneBitProject.Application.Common.Models
{
    using System.Collections.Generic;

    using OneBitProject.Application.Interfaces.Mapping;
    using OneBitProject.Domain.Entities;

    public class CustomerLookupModel : IMapFrom<Customer>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string Status { get; set; }

        public string PhoneNumber { get; set; }

        public string CreatedOn { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
