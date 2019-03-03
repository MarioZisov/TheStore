namespace TheStore.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using TheStore.Core.Domain;

    public class TheStoreContext : DbContext, IDbContext
    {
        public TheStoreContext()
            : base("name=TheStoreContext")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductAttribute> ProductsAttributes { get; set; }

        public DbSet<ProductAttributeValue> ProductsAttriutesValues { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderProduct> OrdersProducts { get; set; }

        public DbSet<ProductAttributeType> ProductAttributeTypes { get; set; }

        public DbSet<Picture> Pictures { get; set; }

        public DbSet<ProductPicture> ProductsPictures { get; set; }

        public DbSet<Product_Attribute_Mapping> ProductsAttributesMapping { get; set; }

        public DbSet<ProductAttribute_AttributeValue_Mapping> ProductAttributesValuesMapping { get; set; }

        public DbSet<Product_Attribute_Value_Mapping> ProductsAttributesValuesMapping { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(m => m.Subcategories)
                .WithMany().
                Map(m =>
                {
                    m.MapLeftKey("CategoryId");
                    m.MapRightKey("SubcategoryId");
                    m.ToTable("CategorySubcategories");
                });

            base.OnModelCreating(modelBuilder);
        }

        IDbSet<TEntity> IDbContext.Set<TEntity>()
        {
            return Set<TEntity>();
        }       
    }
}