using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
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
        private readonly IHostingEnvironment _hostingEnvironment;
        IProductService productService;
        IProductCategoryService prodCategoryService;
        public ProductController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            string webRootPath = _hostingEnvironment.ContentRootPath + "\\Database";
            productService = new ProductService(webRootPath);
            prodCategoryService = new ProductCategoryService(webRootPath);
        }

        [Authorize]
        [Route("ProductList")]
        public IActionResult ProductList()
        {
            var products = productService.GetAll();

            return View(products);
        }

        [Authorize]
        [Route("EditProduct")]
        public IActionResult EditProduct(int id)
        {
            var categories = prodCategoryService.GetAll();
            ViewBag.Categories = new SelectList(categories, "Id", "Title");
            var product = productService.GetById(id);
            return View(product);
        }

        [Authorize]
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

        [Authorize]
        [Route("AddProduct")]
        public IActionResult AddProduct()
        {
            var categories = prodCategoryService.GetAll();
            ViewBag.Categories = new SelectList(categories, "Id", "Title");
            return View(new ProductModel());
        }

        [Authorize]
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

        [Authorize]
        [Route("DeleteProduct")]
        public IActionResult DeleteProduct(int id)
        {
            productService.DeleteProduct(id);
            return RedirectToAction("ProductList", "Product");
        }

        [Route("ProductDetail")]
        public IActionResult ProductDetail(int id)
        {
            var product = productService.GetById(id);
            return View(product);
        }

        [Route("BuyProduct")]
        public IActionResult BuyProduct(int id, int amount)
        {
            var product = productService.GetById(id);
            if (product == null)
            {
                return NotFound("Product is not exist");
            }

            product.Amount -= amount;
            productService.UpdateProduct(product);

            return RedirectToAction("Details", "Product", new { categoryId = product.CategoryId });
        }

        [Route("Details")]
        public IActionResult Details(int categoryId)
        {
            ViewBag.Category = prodCategoryService.GetById(categoryId);
            var products = productService.GetByCategoryId(categoryId);
            return View(products);
        }
    }
}