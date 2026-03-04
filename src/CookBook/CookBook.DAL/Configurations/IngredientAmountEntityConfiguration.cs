using CookBook.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CookBook.DAL.Configurations;

public class IngredientAmountEntityConfiguration : IEntityTypeConfiguration<IngredientAmountEntity>
{
    public void Configure(EntityTypeBuilder<IngredientAmountEntity> builder)
    {
        builder.HasIndex(i => new { i.RecipeId, i.IngredientId })
            .IsUnique();

        builder.Property(i => i.Amount)
            .HasPrecision(18, 2);
    }
}
