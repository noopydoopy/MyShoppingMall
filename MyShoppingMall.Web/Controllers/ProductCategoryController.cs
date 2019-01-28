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
    public class ProductCategoryController : Controller
    {
        private IProductCategoryService prodCategoryService;

        public ProductCategoryController()
        {
            prodCategoryService = new ProductCategoryService();
        }

        public IActionResult Index()
        {
            List<ProductCategoryModel> categories = prodCategoryService.GetAll();
            return View(categories);
        }

        [HttpGet]
        [Route("AddProductCategory")]
        public IActionResult AddProductCategory()
        {
            return View(new ProductCategoryModel());
        }

        [HttpPost]
        [Route("AddProductCategory")]
        public IActionResult AddProductCategory(ProductCategoryModel category)
        {
            if(ModelState.IsValid)
            {
                prodCategoryService.CreateProductCategory(category);
                return RedirectToAction("Index", "ProductCategory");
            }
            return View(new ProductCategoryModel());
        }

        [HttpGet]
        [Route("EditProductCategory")]
        public IActionResult EditProductCategory(int id)
        {
            var category = prodCategoryService.GetById(id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [Route("EditProductCategory")]
        public IActionResult EditProductCategory(ProductCategoryModel category)
        {
            if(ModelState.IsValid)
            {
                prodCategoryService.UpdateProductCategory(category);
                return RedirectToAction("Index", "ProductCategory");
            }
            return View(category);
        }

        [Route("DeleteProductCategory")]
        public IActionResult DeleteProductCategory(int id)
        {
            prodCategoryService.DeleteProductCategory(id);
            return RedirectToAction("Index", "ProductCategory");
        }

    }
}