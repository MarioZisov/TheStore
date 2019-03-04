namespace TheStore.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TheStore.Core.Domain;

    public interface IProductService
    {
        IEnumerable<Product> GetAll();
    }
}
