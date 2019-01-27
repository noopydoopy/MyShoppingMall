using MyShoppingMall.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShoppingMall.Web.Services.Interfaces
{
    public interface IProductService
    {
        List<ProductModel> GetAll();

        ProductModel GetById(int id);

        void UpdateProduct(ProductModel product);

        void CreateProduct(ProductModel product);

        void DeleteProduct(int id);
    }
}
