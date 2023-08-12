using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopGame.DAL.Models;

namespace ShopGame.DAL.Configuration.ModelConfiguration;

public class GameConfiguration:IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title).HasMaxLength(100);
        builder.Property(x => x.ShortDescription).HasMaxLength(1000);
        builder.Property(x => x.Description).HasMaxLength(3000);
        builder.Property(x => x.ImageUrl);
        builder.Property(x => x.InStock);
        builder.Property(x => x.Cost);
        builder.HasOne(x => x.Genre).WithOne(x =>x.Games).HasForeignKey<Game>(x => x.GenreId);
        
       

    }
}