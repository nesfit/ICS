using CookBook.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CookBook.DAL.Configurations;

public class RecipeEntityConfiguration : IEntityTypeConfiguration<RecipeEntity>
{
    public void Configure(EntityTypeBuilder<RecipeEntity> builder)
    {
        builder.Property(i => i.Name)
            .HasMaxLength(200);

        builder.Property(i => i.Description)
            .HasMaxLength(2_000);

        builder.Property(i => i.ImageUrl)
            .HasMaxLength(2_048);

        builder.HasMany(i => i.Ingredients)
            .WithOne(i => i.Recipe)
            .HasForeignKey(i => i.RecipeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
