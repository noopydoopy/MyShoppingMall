using JsonDatabaseConnector;
using MyShoppingMall.Web.Models;
using MyShoppingMall.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShoppingMall.Web.Services
{
    public class ProductService : IProductService
    {
        private DataAccessAdapter adapter;
        public ProductService()
        {
            adapter = new DataAccessAdapter();
        }
        public void CreateProduct(ProductModel product)
        {
            adapter.SaveEntity<ProductModel>(product, "Product");
        }

        public void DeleteProduct(int id)
        {
            var products = adapter.GetEntities<ProductModel>("Product");
            var product = products.FirstOrDefault(c => c.Id == id);
            if (product != null)
            {
                adapter.DeleteEntity<ProductModel>(product, "Product");
            }

        }

        public List<ProductModel> GetAll()
        {
            var products = adapter.GetEntities<ProductModel>("Product");
            return products;
        }

        public List<ProductModel> GetByCategoryId(int categoryId)
        {
            var products = adapter.GetEntities<ProductModel>("Product");
            return products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public ProductModel GetById(int id)
        {
            var products = adapter.GetEntities<ProductModel>("Product");
            var product = products.FirstOrDefault(c => c.Id == id);
            return product;
        }

        public void UpdateProduct(ProductModel product)
        {
            adapter.UpdateEntity<ProductModel>(product, "Product");
        }
    }
}
