﻿using System.Collections.Generic;
using System.Linq;
using WebStoreGusev.DAL;
using WebStoreGusev.DomainNew;
using WebStoreGusev.DomainNew.Entities;
using WebStoreGusev.Infrastructure.Interfaces;

namespace WebStoreGusev.Infrastructure.Services
{
    public class SqlProductService : IProductService
    {
        private readonly WebStoreContext _context;

        public SqlProductService(WebStoreContext context)
        {
            _context = context;
        }

        public IEnumerable<Brand> GetBrands()
        {
            return _context.Brands.ToList();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Product> GetProducts(ProductFilter filter)
        {
            var query = _context.Products.AsQueryable();
            if (filter.BrandId.HasValue)
                query = query.Where(c => c.BrandId.HasValue && c.BrandId.Value.Equals(filter.BrandId.Value));
            if (filter.CategoryId.HasValue)
                query = query.Where(c => c.CategoryId.Equals(filter.CategoryId.Value));

            return query.ToList();
        }
    }
}
