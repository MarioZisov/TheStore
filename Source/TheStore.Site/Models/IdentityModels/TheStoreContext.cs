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

        public DbSet<ProductAttribute> Attributes { get; set; }

        public DbSet<AttributeValue> AttributesValues { get; set; }

        public DbSet<ProductAttributeValue> ProductsAttributesValues { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderProduct> OrdersProducts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(m => m.ProductVarieties)
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