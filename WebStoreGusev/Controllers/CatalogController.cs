using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain;
using WebStoreGusev.Infrastructure.Interfaces;
using WebStoreGusev.Models;

namespace WebStoreGusev.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductService _productService;

        public CatalogController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Shop(int? categoryId, int? brandId)
        {
            var products = _productService.GetProducts(
                new ProductFilter { BrandId = brandId, CategoryId = categoryId });

            var model = new CatalogViewModel()
            {
                BrandId = brandId,
                CategoryId = categoryId,
                Products = products.Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    Name = p.Name,
                    Order = p.Order,
                    Price = p.Price
                }).OrderBy(p => p.Order)
                    .ToList()
            };

            return View(model);
        }

        public IActionResult ProductDetails()
        {
            return View();
        }
    }
}