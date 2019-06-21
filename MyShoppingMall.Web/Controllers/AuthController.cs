using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MyShoppingMall.Web.Models;
using MyShoppingMall.Web.Services;
using MyShoppingMall.Web.Services.Interfaces;

namespace MyShoppingMall.Web.Controllers
{
    [Route("Auth")]
    public class AuthController : Controller
    {
        IUserService userService;

        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route("Signin")]
        public IActionResult Signin()
        {
            return View(new SigninModel());
        }

        [HttpPost]
        [Route("Signin")]
        public async Task<IActionResult> Signin(SigninModel model, string returnUrl = null)
        {
            ViewBag.Message = "";
            if(ModelState.IsValid)
            {
                User user;

                if(userService.ValidateCredentials(model.Username, model.Password, out user))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, model.Username),
                        new Claim("name", model.Username)
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", null);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(principal);

                    if (returnUrl != null)
                        return Redirect(returnUrl);

                    return RedirectToAction("Index", "Home");
                }
                else
                    ViewBag.Message = "UserName or password is not correct";

            }

            return View(model);
        }

        [HttpPost]
        [Route("Signout")]
        public async Task<IActionResult> Signout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}