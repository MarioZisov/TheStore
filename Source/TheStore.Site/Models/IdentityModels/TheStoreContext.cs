using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TheStore.Site.Data;

namespace TheStore.Site.Models
{
    public class TheStoreContext : IdentityDbContext<ApplicationUser>
    {
        public TheStoreContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductTranslation> ProductsTranslations { get; set; }

        public DbSet<ProductPriceCurrency> ProductsPricesCurrencies { get; set; }

        public DbSet<ProductAttribute> Attributes { get; set; }

        public DbSet<AttributeTranslation> AttributesTranslations { get; set; }

        public DbSet<AttributeValue> AttributesValues { get; set; }

        public DbSet<AttributeValueTranslations> AttributeValueTranslations { get; set; }

        public DbSet<ProductAttributeValue> ProductsAttributesValues { get; set; }

        public DbSet<AdditionalAttributeValue> AdditionalAttributesValues { get; set; }

        public DbSet<AdditionalAttributeValueTranslation> AdditionalAttributesValuesTranslations { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CategoryTranslation> CategoryTranslations { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderProduct> OrdersProducts { get; set; }

        public DbSet<AttributeCategory> AttributesCategories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(m => m.VarietyProducts)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("ProductId");
                    m.MapRightKey("VarietyProductId");
                    m.ToTable("ProductVarieties");
                });

            modelBuilder.Entity<Category>()
                .HasMany(m => m.Subcategories)
                .WithMany().
                Map(m =>
                {
                    m.MapLeftKey("CategoryId");
                    m.MapRightKey("SubcategoryId");
                    m.ToTable("Subcategories");
                });

            base.OnModelCreating(modelBuilder);
    }

    public static TheStoreContext Create()
    {
        return new TheStoreContext();
    }
}
}