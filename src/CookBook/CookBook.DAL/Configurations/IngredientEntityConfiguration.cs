using CookBook.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CookBook.DAL.Configurations;

public class IngredientEntityConfiguration : IEntityTypeConfiguration<IngredientEntity>
{
    public void Configure(EntityTypeBuilder<IngredientEntity> builder)
    {
        builder.Property(i => i.Name)
            .HasMaxLength(200);

        builder.Property(i => i.Description)
            .HasMaxLength(2_000);

        builder.Property(i => i.ImageUrl)
            .HasMaxLength(2_048);

        builder.HasMany<IngredientAmountEntity>()
            .WithOne(i => i.Ingredient)
            .HasForeignKey(i => i.IngredientId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
