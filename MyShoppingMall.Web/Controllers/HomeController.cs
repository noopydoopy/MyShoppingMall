using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyShoppingMall.Web.Models;
using MyShoppingMall.Web.Services;
using MyShoppingMall.Web.Services.Interfaces;

namespace MyShoppingMall.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        IProductCategoryService productService;
        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            string webRootPath = _hostingEnvironment.ContentRootPath + "\\Database";
            productService = new ProductCategoryService(webRootPath);
        }

        public IActionResult Index()
        {
            var productCategories = productService.GetProductCategoryWithProduct(3);
            ViewBag.Categories = productCategories;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
