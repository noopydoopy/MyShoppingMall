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

        void CreateProductCategiry(ProductCategoryModel prodCategory);

        void UpdateProductCategory(ProductCategoryModel prodCategory);

        void DeleteProductCategory(int id);
    }
}
