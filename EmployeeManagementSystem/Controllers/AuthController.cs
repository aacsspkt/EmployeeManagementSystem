using EmployeeManagementSystem.Foundations;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUnitOfWork unitWork;

        public AuthController(IUnitOfWork unitOfWork)
        {
            unitWork = unitOfWork;
        }    

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await unitWork.Users.SingleOrDefaultAsync(u => u.Email == loginViewModel.Email);
                if(user == null)
                {
                    ModelState.AddModelError("Email", "Email not found.");
                    return View("Index", loginViewModel);
                } else if (user.Password != loginViewModel.Password)
                {
                    ModelState.AddModelError("Password", "Password not matched.");
                    return View("Index", loginViewModel);
                }
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loginViewModel.Email),
                    new Claim("Password", loginViewModel.Password),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                if (user.Role == Role.Admin)
                {
                    return Redirect("/Admin");
                }
                return Redirect("/");
            }
            return Redirect("/");           
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
        
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
