using MyShoppingMall.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShoppingMall.Web.Services.Interfaces
{
    public interface IProductCategoryService
    {
        List<ProductCategoryModel> GetAll();

        ProductCategoryModel GetById(int id);

        void CreateProductCategory(ProductCategoryModel prodCategory);

        void UpdateProductCategory(ProductCategoryModel prodCategory);

        void DeleteProductCategory(int id);

        List<ProductCategoryModel> GetProductCategoryWithProduct(int? maxProduct = null);
    }
}
