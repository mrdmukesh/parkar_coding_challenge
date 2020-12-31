using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRegistration.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRegistration.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<IdentityUser> useManager { get; set; }
        public SignInManager<IdentityUser> signInManager { get; set; }

        public AccountController(UserManager<IdentityUser> _useManager, SignInManager<IdentityUser> _signInManager)
        {
            useManager = _useManager;
            signInManager = _signInManager;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task< IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = registerViewModel.Email, Email = registerViewModel.Email };
                var result = await useManager.CreateAsync(user, registerViewModel.Password);


                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("",error.Description );
                }
            }

            return View(registerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult>  LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel,string reurl)
        {
            if (ModelState.IsValid)
            {
              
                var result = await signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.Rememberme,false);


                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(reurl) && Url.IsLocalUrl(reurl))
                    {
                        return LocalRedirect(reurl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                
                    ModelState.AddModelError("", "Invalid login attempt ");
                
            }

            return View(loginViewModel);
        }
    }
}