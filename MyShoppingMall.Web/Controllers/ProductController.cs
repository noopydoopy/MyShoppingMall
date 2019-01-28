using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyShoppingMall.Web.Models;
using MyShoppingMall.Web.Services;
using MyShoppingMall.Web.Services.Interfaces;

namespace MyShoppingMall.Web.Controllers
{
    [Route("Product")]
    public class ProductController : Controller
    {
        IProductService productService;
        private IProductCategoryService prodCategoryService;
        public ProductController()
        {
            productService = new ProductService();
            prodCategoryService = new ProductCategoryService();
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
            var categories = prodCategoryService.GetAll();
            ViewBag.Categories = new SelectList(categories, "Id", "Title");
            var product = productService.GetById(id);
            return View(product);
        }

        [Route("EditProduct")]
        [HttpPost]
        public IActionResult EditProduct(ProductModel product)
        {
            var categories = prodCategoryService.GetAll();
            ViewBag.Categories = new SelectList(categories, "Id", "Title");
            if (ModelState.IsValid)
            {
                productService.UpdateProduct(product);
                return RedirectToAction("ProductList", "Product");
            }
            return View(product);
        }

        [Route("AddProduct")]
        public IActionResult AddProduct()
        {
            var categories = prodCategoryService.GetAll();
            ViewBag.Categories = new SelectList(categories, "Id", "Title");
            return View(new ProductModel());
        }

        [Route("AddProduct")]
        [HttpPost]
        public IActionResult AddProduct(ProductModel product)
        {
            var categories = prodCategoryService.GetAll();
            ViewBag.Categories = new SelectList(categories, "Id", "Title");

            if (ModelState.IsValid)
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