using JsonDatabaseConnector;
using MyShoppingMall.Web.Models;
using MyShoppingMall.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShoppingMall.Web.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private DataAccessAdapter adapter;

        public ProductCategoryService(string dbPath)
        {
            adapter = new DataAccessAdapter(dbPath);
        }
        public void CreateProductCategory(ProductCategoryModel prodCategory)
        {
            adapter.SaveEntity<ProductCategoryModel>(prodCategory, "ProductCategory");
        }

        public void DeleteProductCategory(int id)
        {
            var category = GetById(id);
            if (category != null)
                adapter.DeleteEntity<ProductCategoryModel>(category, "ProductCategory");
        }

        public List<ProductCategoryModel> GetAll()
        {
            var categories = adapter.GetEntities<ProductCategoryModel>("ProductCategory");
            return categories;
        }

        public ProductCategoryModel GetById(int id)
        {
            var categories = adapter.GetEntities<ProductCategoryModel>("ProductCategory");
            var category = categories.SingleOrDefault(c => c.Id == id);
            return category;
        }

        public List<ProductCategoryModel> GetProductCategoryWithProduct(int? maxProduct = null)
        {
            var categories = adapter.GetEntities<ProductCategoryModel>("ProductCategory");
            var products = adapter.GetEntities<ProductModel>("Product");
            foreach (var cat in categories)
            {
                if (maxProduct.HasValue)
                    cat.Products = products.Where(p => p.CategoryId == cat.Id).Take(maxProduct.Value).ToList();
                else
                    cat.Products = products.Where(p => p.CategoryId == cat.Id).ToList();
            }

            return categories;
        }

        public void UpdateProductCategory(ProductCategoryModel prodCategory)
        {
            adapter.UpdateEntity<ProductCategoryModel>(prodCategory, "ProductCategory");
        }
    }
}
