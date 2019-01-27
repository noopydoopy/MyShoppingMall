using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyShoppingMall.Web.Models;
using MyShoppingMall.Web.Services;
using MyShoppingMall.Web.Services.Interfaces;

namespace MyShoppingMall.Web.Controllers
{
    [Route("Product")]
    public class ProductController : Controller
    {
        IProductService productService;
        public ProductController()
        {
            productService = new ProductService();
        }

        [Route("ProductList")]
        public IActionResult ProductList()
        {
            var products = productService.GetAll();

            return View(products);
        }

        [Route("EditProduct")]
        public IActionResult EditProduct(int id)
        {
            var product = productService.GetById(id);
            return View(product);
        }

        [Route("EditProduct")]
        [HttpPost]
        public IActionResult EditProduct(ProductModel product)
        {
            if(ModelState.IsValid)
            {
                productService.UpdateProduct(product);
                return RedirectToAction("ProductList", "Product");
            }
            return View(product);
        }

        [Route("AddProduct")]
        public IActionResult AddProduct()
        {
            return View(new ProductModel());
        }

        [Route("AddProduct")]
        [HttpPost]
        public IActionResult AddProduct(ProductModel product)
        {
            if(ModelState.IsValid)
            {
                productService.CreateProduct(product);
                return RedirectToAction("ProductList", "Product");
            }
            return View(product);
        }

        [Route("DeleteProduct")]
        public IActionResult DeleteProduct(int id)
        {
            productService.DeleteProduct(id);
            return RedirectToAction("ProductList", "Product");
        }
    }
}