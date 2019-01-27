using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyShoppingMall.Web.Models;

namespace MyShoppingMall.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var AppSetting = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();
            string path = AppSetting["databaseDir"];
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
