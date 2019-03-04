namespace TheStore.Services.ProductServiceComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TheStore.Core.Domain;
    using TheStore.Data;
    using TheStore.Services.Interfaces;

    public class ProductService : IProductService
    {
        private readonly IRepository<Product> ProductRepository;

        public ProductService(IRepository<Product> ProductRepository)
        {
            this.ProductRepository = ProductRepository ?? throw new ArgumentNullException(nameof(ProductRepository));
        }

        public IEnumerable<Product> GetAll()
        {
            var products = this.ProductRepository.Table.Where(x => x.Deleted == false).ToList();
            return products;
        }
    }
}
