namespace OneBigProject.Persistence.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using OneBitProject.Domain.Entities;

    public static class OrderConfiguration
    {
        public static void Configure(this ModelBuilder builder)
        {
            builder.Entity<Order>()
                .HasKey(x => x.Id);

            builder.Entity<Order>()
                .Property(x => x.Quantity)
                .IsRequired();

            builder.Entity<Order>()
                .Property(x => x.Description)
                .IsRequired();

            builder.Entity<Order>()
                .Property(x => x.Status)
                .IsRequired();

            builder.Entity<Order>()
                .Property(x => x.TotalAmount)
                .IsRequired()
                .HasColumnType("money");
        }
    }
}
