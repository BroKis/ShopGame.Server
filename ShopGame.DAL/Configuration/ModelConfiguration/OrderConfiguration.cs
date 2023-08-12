using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopGame.DAL.Models;

namespace ShopGame.DAL.Configuration.ModelConfiguration;

public class OrderConfiguration:IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.OrderTime);
        builder.HasOne(x => x.Game)
            .WithOne(x => x.Order)
            .HasForeignKey<Order>(x => x.GameID);
    }
}