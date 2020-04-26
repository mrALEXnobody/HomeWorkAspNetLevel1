using System.Collections.Generic;
using WebStore.Domain;
using WebStore.Domain.Entities;

namespace WebStoreGusev.Infrastructure.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Category> GetCategories();
        IEnumerable<Brand> GetBrands();
        IEnumerable<Product> GetProducts(ProductFilter filter);
    }
}