namespace OneBigProject.Persistence.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using OneBitProject.Domain.Entities;

    public static class CustomerConfiguration
    {
        public static void Configure(this ModelBuilder builder)
        {
            builder.Entity<Customer>()
                .HasKey(x => x.Id);

            builder.Entity<Customer>()
                .Property(x => x.FirstName)
                .IsRequired();

            builder.Entity<Customer>()
                .Property(x => x.LastName)
                .IsRequired();
            
            builder.Entity<Customer>()
                .Property(x => x.PhoneNumber)
                .IsRequired();

            builder.Entity<Customer>()
                .Property(x => x.Status)
                .IsRequired();

            builder.Entity<Customer>()
                .Property(x => x.Gender)
                .IsRequired();

            builder.Entity<Customer>()
                .HasMany(x => x.Orders)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerId);
        }
    }
}